using System;
using Huobi.SDK.Core.Model;
using Newtonsoft.Json;
using WebSocketSharp;

namespace Huobi.SDK.Core.Client.WebSocketClientBase
{
    /// <summary>
    /// The abstract class that responsible to get data from websocket
    /// </summary>
    /// <typeparam name="DataResponseType"></typeparam>
    public abstract class WebSocketClientBase<DataResponseType>
    {
        protected const string DEFAULT_HOST = "api.huobi.pro/ws";

        protected WebSocket _WebSocket;

        public delegate void OnResponseReceivedHandler(DataResponseType response);
        public event OnResponseReceivedHandler OnResponseReceived;

        public delegate void OnErrorHandler(string data);
        public event OnErrorHandler OnError;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websocket host</param>
        public WebSocketClientBase(string host = DEFAULT_HOST)
        {
            _WebSocket = new WebSocket($"wss://{host}");
            _WebSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.None;

            _WebSocket.OnMessage += _ws_OnMessage;
            _WebSocket.OnError += _ws_OnError;
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
                    var response = JsonConvert.DeserializeObject<DataResponseType>(data);

                    OnResponseReceived?.Invoke(response);
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
