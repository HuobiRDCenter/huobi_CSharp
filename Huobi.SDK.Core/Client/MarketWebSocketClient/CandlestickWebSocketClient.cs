using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle candlestick data from WebSocket
    /// </summary>
    public class CandlestickWebSocketClient : WebSocketClientBase<SubscribeCandlestickResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public CandlestickWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
        {
        }

        /// <summary>
        /// Request the full candlestick data according to specified criteria
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="period">Candlestick internval
        /// possible values: 1min, 5min, 15min, 30min, 60min, 4hour, 1day, 1mon, 1week, 1year</param>
        /// <param name="from">From timestamp in second</param>
        /// <param name="to">To timestamp in second</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string period, int from, int to, string clientId = "")
        {
            string topic = $"market.{symbol}.kline.{period}";

            _WebSocket.Send($"{{ \"req\": \"{topic}\",\"id\": \"{clientId}\", \"from\":{from}, \"to\":{to} }}");

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Subscribe candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="period">Candlestick internval</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string period, string clientId = "")
        {
            string topic = $"market.{symbol}.kline.{period}";

            _WebSocket.Send($"{{ \"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="period">Candlestick interval</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string period, string clientId = "")
        {
            string topic = $"market.{symbol}.kline.{period}";

            _WebSocket.Send($"{{ \"unsub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
