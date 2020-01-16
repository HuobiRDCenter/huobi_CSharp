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
    public abstract class WebSocketV2ClientBase<DataResponseType>
    {
        public delegate void OnAuthenticationReceivedHandler(WebSocketAuthenticationV2Response response);
        public event OnAuthenticationReceivedHandler OnAuthenticationReceived;

        public delegate void OnDataReceivedHandler(DataResponseType response);
        public event OnDataReceivedHandler OnDataReceived;

        public delegate void OnErrorHandler(string data);
        public event OnErrorHandler OnError;

        protected const string DEFAULT_HOST = "api.huobi.pro";
        protected const string PATH = "/ws/v2";

        protected WebSocket _WebSocket;

        private readonly WebSocketV2RequestBuilder _wsV2ReqBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websocket host</param>
        public WebSocketV2ClientBase(string accessKey, string secretKey, string host = DEFAULT_HOST)
        {
            _WebSocket = new WebSocket($"wss://{host}{PATH}");
            _WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            _WebSocket.OnOpen += _ws_OnOpen;
            _WebSocket.OnMessage += _ws_OnMessage;
            _WebSocket.OnError += _ws_OnError;

            _wsV2ReqBuilder = new WebSocketV2RequestBuilder(accessKey, secretKey, host, PATH);
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
            string authRequest = _wsV2ReqBuilder.Build();

            _WebSocket.Send(authRequest);
        }

        private void _ws_OnMessage(object sender, MessageEventArgs e)
        {
            string data = e.Data;

            if (e.IsBinary)
            {
                data = GZipDecompresser.Decompress(e.RawData);
            }

            dynamic json = JToken.Parse(data);
            string ch = json.action;
            switch (ch)
            {
                case "ping":
                    {
                        var pingMessageV2 = JsonConvert.DeserializeObject<PingMessageV2>(data);
                        if (pingMessageV2 != null && pingMessageV2.data != null && pingMessageV2.data.ts != 0)
                        {
                            long ts = pingMessageV2.data.ts;

                            Console.WriteLine($"received ping:{ts}");

                            string pongData = $"{{\"action\": \"pong\", \"data\": {{\"ts\":{ts} }} }}";
                            _WebSocket.Send(pongData);

                            Console.WriteLine($"replied pong:{ts}");
                        }
                        break;
                    }
                case "req":
                    {
                        var response = JsonConvert.DeserializeObject<WebSocketAuthenticationV2Response>(data);

                        OnAuthenticationReceived?.Invoke(response);

                        break;
                    }
                case "push":
                    {
                        var response = JsonConvert.DeserializeObject<DataResponseType>(data);

                        OnDataReceived?.Invoke(response);

                        break;
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
