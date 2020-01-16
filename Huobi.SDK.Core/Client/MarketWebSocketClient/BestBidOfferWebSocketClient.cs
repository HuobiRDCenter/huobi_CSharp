using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle BBO data from WebSocket
    /// </summary>
    public class BestBidOfferWebSocketClient : WebSocketClientBase<SubscribeBestBidOfferResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public BestBidOfferWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Subscribe latest market by price order book in snapshot mode at 1-second interval.
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.bbo\",\"id\": \"{clientId}\" }}");
        }

        /// <summary>
        /// Unsubscribe market by price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.bbo\",\"id\": \"{clientId}\" }}");
        }
    }
}
