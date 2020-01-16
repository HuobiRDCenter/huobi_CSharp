using Huobi.SDK.Core.Client.WebSocketClientBase;
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
            string req = $"{{\"req\": \"market.{symbol}.kline.{period}\",\"id\": \"{clientId}\", \"from\":{from}, \"to\":{to} }}";

            _WebSocket.Send(req);
        }

        /// <summary>
        /// Subscribe candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="period">Candlestick internval</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string period, string clientId = "")
        {
            _WebSocket.Send($"{{\"sub\": \"market.{symbol}.kline.{period}\",\"id\": \"{clientId}\" }}");
        }

        /// <summary>
        /// Unsubscribe candlestick data
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="period">Candlestick interval</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string period, string clientId = "")
        {
            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.kline.{period}\",\"id\": \"{clientId}\" }}");
        }
    }
}
