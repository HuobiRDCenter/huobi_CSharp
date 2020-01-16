using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle Depth data from WebSocket
    /// </summary>
    public class DepthWebSocketClient : WebSocketClientBase<SubscribeDepthResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public DepthWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request full depth data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="type">Market depth aggregation level
        /// Possible values: step0, step1, step2, step3, step4, step5</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string type, string clientId = "")
        {
            string req = $"{{\"req\": \"market.{symbol}.depth.{type}\",\"id\": \"{clientId}\" }}";

            _WebSocket.Send(req);
        }


        /// <summary>
        /// Subscribe latest market by price order book in snapshot mode at 1-second interval.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="type">Market depth aggregation level</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string type, string clientId = "")
        {
            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.depth.{type}\",\"id\": \"{clientId}\" }}");
        }

        /// <summary>
        /// Unsubscribe market by price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="type">Market depth aggregation level</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string type, string clientId = "")
        {
            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.depth.{type}\",\"id\": \"{clientId}\" }}");
        }
    }
}
