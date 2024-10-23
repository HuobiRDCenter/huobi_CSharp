﻿using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle MBP data from WebSocket
    /// </summary>
    public class MarketByPriceWebSocketClient : WebSocketClientBase<SubscribeMarketByPriceResponse>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">websockethost</param>
        public MarketByPriceWebSocketClient(string host = DEFAULT_HOST)
            :base(host)
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
        /// <param name="clientId">Client id</param>
        public void Req(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.150";

            _WebSocket.Send($"{{\"req\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket request, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Subscribe incremental update of Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.150";

            _WebSocket.Send($"{{\"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.150";

            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.mbp.150\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Subscribe full Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="level">Number of price levels: 5, 10, 20</param>
        /// <param name="clientId">Client id</param>
        public void SubscribeFull(string symbol, int level, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.refresh.{level}";

            _WebSocket.Send($"{{\"sub\": \"{topic}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe full Market By Price order book
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="level">Number of price levels: 5, 10, 20</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribeFull(string symbol, int level, string clientId = "")
        {
            string topic = $"market.{symbol}.mbp.refresh.{level}";

            _WebSocket.Send($"{{\"unsub\": \"market.{symbol}.mbp.refresh.{level}\",\"id\": \"{clientId}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}
