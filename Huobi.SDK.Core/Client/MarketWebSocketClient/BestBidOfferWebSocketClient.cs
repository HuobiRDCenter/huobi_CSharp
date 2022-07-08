using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Market;

namespace HuobiSDK.Core.Client
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
            string topic = $"market.{symbol}.bbo";

            _WebSocket.Send($"{{\"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe market by price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.bbo";

            _WebSocket.Send($"{{\"unsub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
