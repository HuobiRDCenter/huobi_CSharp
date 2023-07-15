using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Market;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle Trade data from WebSocket
    /// </summary>
    public class TradeWebSocketClient : WebSocketClientBase<SubscribeTradeResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public TradeWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request latest 300 trade data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.trade.detail";

            _WebSocket.Send($"{{\"req\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={topic}, clientId={clientId}");
        }


        /// <summary>
        /// Subscribe latest completed trade in tick by tick mode
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.trade.detail";

            _WebSocket.Send($"{{ \"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe trade
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.trade.detail";

            _WebSocket.Send($"{{ \"unsub\": \"market.{symbol}.trade.detail\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
