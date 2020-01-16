using System;
using Huobi.SDK.Core.Model;
using Huobi.SDK.Core.RequestBuilder;
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
    public abstract class WebSocketV1ClientBase<DataResponseType>
    {
        public delegate void OnAuthenticationReceivedHandler(WebSocketAuthenticationV1Response response);
        public event OnAuthenticationReceivedHandler OnAuthenticationReceived;

        public delegate void OnDataReceivedHandler(DataResponseType response);
        public event OnDataReceivedHandler OnDataReceived;

        public delegate void OnErrorHandler(string data);
        public event OnErrorHandler OnError;

        protected const string DEFAULT_HOST = "api.huobi.pro";
        protected const string PATH = "/ws/v1";

        protected WebSocket _WebSocket;

        private readonly WebSocketV1RequestBuilder _wsV1ReqBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websocket host</param>
        public WebSocketV1ClientBase(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _WebSocket = new WebSocket($"wss://{host}{PATH}");
            _WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            _WebSocket.OnOpen += _ws_OnOpen;
            _WebSocket.OnMessage += _ws_OnMessage;
            _WebSocket.OnError += _ws_OnError;

            _wsV1ReqBuilder = new WebSocketV1RequestBuilder(accessKey, secretKey, host, PATH);
        }

        /// <summary>
        /// Connect to websocket server
        /// </summary>
        public void Connect()
        {
            _WebSocket.Connect();
        }

        /// <summary>
        /// Disconnect to websocket server
        /// </summary>
        public void Disconnect()
        {
            _WebSocket.Close();
        }

        private void _ws_OnOpen(object sender, EventArgs e)
        {
            string authRequest = _wsV1ReqBuilder.Build();
            _WebSocket.Send(authRequest);
        }

        private void _ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsBinary)
            {
                string data = GZipDecompresser.Decompress(e.RawData);

                var pingMessage = JsonConvert.DeserializeObject<PingMessage>(data);
                if (pingMessage != null && pingMessage.ping != 0)
                {
                    Console.WriteLine($"received ping:{pingMessage.ping}");
                    string pongData = $"{{\"pong\":{pingMessage.ping}}}";
                    _WebSocket.Send(pongData);
                    Console.WriteLine($"replied pong:{pingMessage.ping}");
                }
                else
                {
                    dynamic json = JToken.Parse(data);
                    string op = json.op;
                    if (String.Equals(op, "auth"))
                    {
                        var response = JsonConvert.DeserializeObject<WebSocketAuthenticationV1Response>(data);

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

        private void _ws_OnError(object sender, ErrorEventArgs e)
        {
            OnError?.Invoke(e.Exception.Message);
            OnError?.Invoke(e.Message);
        }
    }
}
