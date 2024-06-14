using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle ticker data from WebSocket
    /// </summary>
    public class MarketTickerWebSocketClient : WebSocketClientBase<SubscribeTickerResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public MarketTickerWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request full Ticker data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        public void Req(string symbol)
        {
            string topic = $"market.{symbol}.ticker";

            _WebSocket.Send($"{{\"req\": \"{topic}\"}}");

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={topic}");
        }


        /// <summary>
        /// Subscribe Ticker
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        public void Subscribe(string symbol)
        {
            string topic = $"market.{symbol}.ticker";

            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.ticker\"}}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}");
        }

        /// <summary>
        /// Unsubscribe ticker
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        public void UnSubscribe(string symbol)
        {
            string topic = $"market.{symbol}.ticker";

            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.ticker\"}}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}");
        }
    }
}