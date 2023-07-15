using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Market;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle last 24h candlestick data from WebSocket
    /// </summary>
    public class Last24hCandlestickWebSocketClient : WebSocketClientBase<SubscribeLast24hCandlestickResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public Last24hCandlestickWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request full candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.detail";

            _WebSocket.Send($"{{\"req\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={topic}, clientId={clientId}");
        }


        /// <summary>
        /// Subscribe latest 24h market stats
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.detail";

            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.detail\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe latest 24 market stats
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.detail";

            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.detail\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
