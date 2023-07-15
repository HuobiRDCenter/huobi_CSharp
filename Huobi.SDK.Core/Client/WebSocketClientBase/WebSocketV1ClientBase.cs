using HuobiSDK.Core.Model;
using HuobiSDK.Core.RequestBuilder;
using HuobiSDK.Model.Response.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Timers;
using WebSocketSharp;

namespace HuobiSDK.Core.Client.WebSocketClientBase
{
    /// <summary>
    /// The abstract class that responsible to get data from websocket authentication v1
    /// </summary>
    /// <typeparam name="DataResponseType"></typeparam>
    public abstract class WebSocketV1ClientBase<DataResponseType> : AbstractWebSocketClient
    {
        public delegate void OnAuthenticationReceivedHandler(WebSocketV1AuthResponse response);
        public event OnAuthenticationReceivedHandler OnAuthenticationReceived;
        public delegate void OnDataReceivedHandler(DataResponseType response);
        public event OnDataReceivedHandler OnDataReceived;

        protected const string DEFAULT_HOST = "api.huobi.pro";
        protected const string PATH = "/ws/v1";
        private string _host;

        protected WebSocket _WebSocket;
        public bool _autoConnect;

        private Timer _timer;
        private const int TIMER_INTERVAL_SECOND = 5;
        private DateTime _lastReceivedTime;
        private const int RECONNECT_WAIT_SECOND = 60;
        private const int RENEW_WAIT_SECOND = 120;

        private readonly WebSocketV1RequestBuilder _wsV1ReqBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websocket host</param>
        public WebSocketV1ClientBase(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _host = host;

            _timer = new Timer(TIMER_INTERVAL_SECOND * 1000);
            _timer.Elapsed += _timer_Elapsed;

            InitializeWebSocket();

            _wsV1ReqBuilder = new WebSocketV1RequestBuilder(accessKey, secretKey, host, PATH);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            double elapsedSecond = (DateTime.UtcNow - _lastReceivedTime).TotalSeconds;
            _logger.Log(Log.LogLevel.Trace, $"WebSocket received data {elapsedSecond.ToString("0.00")} sec ago");

            if (elapsedSecond > RECONNECT_WAIT_SECOND && elapsedSecond <= RENEW_WAIT_SECOND)
            {
                _logger.Log(Log.LogLevel.Info, "WebSocket reconnecting...");
                _WebSocket.Close();
                _WebSocket.Connect();
            }
            else if (elapsedSecond > RENEW_WAIT_SECOND)
            {
                _logger.Log(Log.LogLevel.Info, "WebSocket re-initialize...");
                Disconnect();
                UninitializeWebSocket();
                InitializeWebSocket();
                Connect();
            }
        }

        private void InitializeWebSocket()
        {
            _WebSocket = new WebSocket($"wss://{_host}{PATH}");
            _WebSocket.Log.Output = (d, m) =>
            { /* Disable logger */ };

            _WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            _WebSocket.OnError += _WebSocket_OnError;
            _WebSocket.OnOpen += _WebSocket_OnOpen;

            _lastReceivedTime = DateTime.UtcNow;
        }

        private void UninitializeWebSocket()
        {
            _WebSocket.OnOpen -= _WebSocket_OnOpen;
            _WebSocket.OnError -= _WebSocket_OnError;
            _WebSocket = null;
        }

        /// <summary>
        /// Connect to websocket server
        /// </summary>
        /// <param name="autoConnect">whether auto connect to server after it is disconnected</param>
        public override void Connect(bool autoConnect = true)
        {
            _WebSocket.OnMessage += _WebSocket_OnMessage;

            _WebSocket.Connect();

            _autoConnect = autoConnect;
            if (_autoConnect)
            {
                _timer.Enabled = true;
            }
        }

        /// <summary>
        /// Disconnect to websocket server
        /// </summary>
        public override void Disconnect()
        {
            _timer.Enabled = false;

            _WebSocket.OnMessage -= _WebSocket_OnMessage;

            _WebSocket.Close(CloseStatusCode.Normal);
        }

        private void _WebSocket_OnOpen(object sender, EventArgs e)
        {
            _logger.Log(Log.LogLevel.Debug, "WebSocket opened");

            _lastReceivedTime = DateTime.UtcNow;

            string authRequest = _wsV1ReqBuilder.Build();
            _WebSocket.Send(authRequest);
            _logger.Log(Log.LogLevel.Debug, "WebSocket authentication sent");
        }

        private void _WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            _lastReceivedTime = DateTime.UtcNow;

            if (e.IsBinary)
            {
                string data = GZipDecompresser.Decompress(e.RawData);

                var pingMessage = JsonConvert.DeserializeObject<PingMessageV1>(data);
                if (pingMessage.IsPing())
                {
                    _logger.Log(Log.LogLevel.Trace, $"WebSocket received data, ping={pingMessage.ts}");
                    string pongData = $"{{\"op\":\"pong\", \"ts\":{pingMessage.ts}}}";
                    _WebSocket.Send(pongData);
                    _logger.Log(Log.LogLevel.Trace, $"WebSocket repied data, pong={pingMessage.ts}");
                }
                else
                {
                    dynamic json = JToken.Parse(data);
                    string op = json.op;
                    if (string.Equals(op, "auth"))
                    {
                        var response = JsonConvert.DeserializeObject<WebSocketV1AuthResponse>(data);

                        OnAuthenticationReceived?.Invoke(response);
                    }
                    else
                    {
                        var response = JsonConvert.DeserializeObject<DataResponseType>(data);

                        OnDataReceived?.Invoke(response);
                    }
                }
            }
        }

        private void _WebSocket_OnError(object sender, ErrorEventArgs e)
        {
            _logger.Log(Log.LogLevel.Error, $"WebSocket error: {e.Message} | {e.Exception}");
        }
    }
}