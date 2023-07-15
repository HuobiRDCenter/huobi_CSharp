using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Market;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle MBP data from WebSocket
    /// </summary>
    public class MarketByPriceTickWebSocketClient : WebSocketClientBase<SubscribeMarketByPriceResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public MarketByPriceTickWebSocketClient(string host = DEFAULT_HOST)
            :base(host, FEED_PATH)
        {
        }

        /// <summary>
        /// Request full Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol, Only support 39 currency pairs at this point of time
        /// Possible values: btcusdt, ethusdt, eosusdt, bchusdt, ltcusdt, xrpusdt, htusdt, bsvusdt,
        /// etcusdt, zecusdt, ethbtc, eosbtc, bchbtc, ltcbtc, xrpbtc, htbtc, bsvbtc, etcbtc, zecbtc,
        /// idtbtc, hotbtc, xmxeth, zechusd, lxteth, ucbtc, uuubtc, gtceth, mxcbtc, datxbtc, uipbtc,
        /// butbtc, tosbtc, musketh, ftibtc, rteeth, fairbtc, covabtc, renbtc, manbtc
        /// </param>
        /// <param name="level">Depth level</param>
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, int level, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.{level}";

            _WebSocket.Send($"{{\"req\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket request, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Subscribe incremental update of Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="level">Depth level</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, int level, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.{level}";

            _WebSocket.Send($"{{\"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="level">Depth level</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, int level, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.{level}";

            _WebSocket.Send($"{{\"unsub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
