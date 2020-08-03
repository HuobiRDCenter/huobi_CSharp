using System;
using System.Timers;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Core.Model;
using Huobi.SDK.Core.RequestBuilder;
using Huobi.SDK.Model.Response.Auth;
using Huobi.SDK.Model.Response.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace Huobi.SDK.Core.Client.WebSocketClientBase
{
    /// <summary>
    /// The abstract class that responsible to get data from websocket authentication v1
    /// </summary>
    /// <typeparam name="DataResponseType"></typeparam>
    public abstract class WebSocketV2ClientBase<DataResponseType> where DataResponseType : WebSocketV2ResponseBase
    {
        public delegate void OnAuthenticationReceivedHandler(WebSocketV2AuthResponse response);
        public event OnAuthenticationReceivedHandler OnAuthenticationReceived;
        public delegate void OnDataReceivedHandler(DataResponseType response);
        public event OnDataReceivedHandler OnDataReceived;

        protected const string DEFAULT_HOST = "api.huobi.pro";
        protected const string PATH = "/ws/v2";
        private string _host;

        protected WebSocket _WebSocket;
        public bool _autoConnect;

        private Timer _timer;
        private const int TIMER_INTERVAL_SECOND = 5;
        private DateTime _lastReceivedTime;
        private const int RECONNECT_WAIT_SECOND = 60;
        private const int RENEW_WAIT_SECOND = 120;

        private readonly WebSocketV2RequestBuilder _wsV2ReqBuilder;

        protected ILogger _logger = new ConsoleLogger();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websocket host</param>
        public WebSocketV2ClientBase(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _host = host;

            _timer = new Timer(TIMER_INTERVAL_SECOND * 1000);
            _timer.Elapsed += _timer_Elapsed;

            InitializeWebSocket();


            _wsV2ReqBuilder = new WebSocketV2RequestBuilder(accessKey, secretKey, host, PATH);
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
        public void Connect(bool autoConnect = true)
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
        public void Disconnect()
        {
            _timer.Enabled = false;

            _WebSocket.OnMessage -= _WebSocket_OnMessage;

            _WebSocket.Close(CloseStatusCode.Normal);
        }

        private void _WebSocket_OnOpen(object sender, EventArgs e)
        {
            _logger.Log(Log.LogLevel.Debug, "WebSocket opened");

            _lastReceivedTime = DateTime.UtcNow;

            string authRequest = _wsV2ReqBuilder.Build();
            _WebSocket.Send(authRequest);
        }

        private void _WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            _lastReceivedTime = DateTime.UtcNow;

            string data = e.Data;

            if (e.IsBinary)
            {
                data = GZipDecompresser.Decompress(e.RawData);
            }

            dynamic json = JToken.Parse(data);
            string ch = json.action;
            switch (ch)
            {
                case "ping": // Receive Ping message
                    {
                        var pingMessageV2 = JsonConvert.DeserializeObject<PingMessageV2>(data);
                        if (pingMessageV2 != null && pingMessageV2.data != null && pingMessageV2.data.ts != 0)
                        {
                            long ts = pingMessageV2.data.ts;

                            _logger.Log(Log.LogLevel.Trace, $"WebSocket received data, ping={ts}");

                            string pongData = $"{{\"action\": \"pong\", \"data\": {{\"ts\":{ts} }} }}";
                            _WebSocket.Send(pongData);

                            _logger.Log(Log.LogLevel.Trace, $"WebSocket replied data, pong={ts}");
                        }
                        break;
                    }
                case "req": // Receive authentication response
                    {
                        var response = JsonConvert.DeserializeObject<WebSocketV2AuthResponse>(data);

                        OnAuthenticationReceived?.Invoke(response);

                        break;
                    }
                case "sub": // Receive subscription response
                case "push": // Receive data response
                    {
                        var response = JsonConvert.DeserializeObject<DataResponseType>(data);

                        OnDataReceived?.Invoke(response);

                        break;
                    }
            }

        }

        private void _WebSocket_OnError(object sender, ErrorEventArgs e)
        {
            _logger.Log(Log.LogLevel.Error, $"WebSocket error: {e.Message}");
        }
    }
}
