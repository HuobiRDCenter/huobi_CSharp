using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    public class MarketClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetCandlestick();

            GetLast24hCandlestickAskBid();

            GetAllSymbolsLast24hCandlesticksAskBid();

            GetDepth();

            GetLastTrade();

            GetLastTrades();

            GetLast24Candlestick();
        }

        private static void GetCandlestick()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "btcusdt")
                .AddParam("period", "1min")
                .AddParam("size", "10");
            var result = marketClient.GetCandlestickAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                foreach (var c in result.data)
                {
                    AppLogger.Info($"local time: {Timestamp.SToLocal(c.id)}, count: {c.count}, amount: {c.amount}, volume: {c.vol}");
                }
                AppLogger.Info($"there are total {result.data.Length} candlesticks");
            }

        }

        private static void GetLast24hCandlestickAskBid()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var result = marketClient.GetLast24hCandlestickAskBidAsync("btcusdt").Result;
            _logger.StopAndLog();

            if (result != null && result.tick != null)
            {
                var ts = result.ts;
                var t = result.tick;

                AppLogger.Info($"local time: {Timestamp.MSToLocal(ts)}, ask: [{t.ask[0]}, {t.ask[1]}], bid: [{t.bid[0]} {t.bid[1]}]");
            }
        }

        private static void GetAllSymbolsLast24hCandlesticksAskBid()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var result = marketClient.GetAllSymbolsLast24hCandlesticksAskBidAsync().Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                foreach (var t in result.data)
                {
                    AppLogger.Info($"symbol: {t.symbol}, count {t.count}, amount: {t.amount}, volume: {t.vol}" +
                        $", bid: [{t.bid}, {t.bidSize}], ask: [{t.ask}, {t.askSize}]");
                }
                AppLogger.Info($"There are total {result.data.Length} candlesticks");

            }
        }

        private static void GetDepth()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "btcusdt")
                .AddParam("depth", "5")
                .AddParam("type", "step0");
            var result = marketClient.GetDepthAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.tick != null)
            {
                var asks = result.tick.asks;
                if (asks != null)
                {
                    for (int i = asks.Length - 1; i >= 0; i--)
                    {
                        AppLogger.Info($"[{asks[i][0]}, {asks[i][1]}]");
                    }
                }
                AppLogger.Info($"----------");
                var bids = result.tick.bids;
                if (bids != null)
                {
                    for (int i = 0; i < bids.Length; i++)
                    {
                        AppLogger.Info($"[{bids[i][0]}, {bids[i][1]}]");
                    }
                }
            }
        }

        private static void GetLastTrade()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var result = marketClient.GetLastTradeAsync("btcusdt").Result;
            _logger.StopAndLog();

            if (result != null && result.tick != null)
            {
                var data = result.tick.data;
                if (data != null)
                {
                    foreach (var t in data)
                    {
                        AppLogger.Info($"singapore time: {Timestamp.MSToLocal(t.ts)}," +
                            $" trade-id: {t.tradeId}, amount: {t.amount}, price: {t.price}, direction: {t.direction}");
                    }
                    AppLogger.Info($"There are latest {data.Length} tradings");
                }
            }
        }

        private static void GetLastTrades()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var result = marketClient.GetLastTradesAsync("btcusdt", 3).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                var data = result.data;
                foreach (var d in data)
                {
                    if (d.data != null)
                    {
                        foreach (var t in d.data)
                        {
                            AppLogger.Info($"singapore time: {Timestamp.MSToLocal(t.ts)}," +
                                $" trade-id: {t.tradeId}, amount: {t.amount}, price: {t.price}, direction: {t.direction}");
                        }
                        AppLogger.Info($"There are latest {d.data.Length} tradings");
                    }
                }
            }
        }

        private static void GetLast24Candlestick()
        {
            var marketClient = new MarketClient();

            _logger.Start();
            var result = marketClient.GetLast24hCandlestickAsync("btcusdt").Result;
            _logger.StopAndLog();

            if (result != null && result.tick != null)
            {
                var ts = result.ts;
                var t = result.tick;
                AppLogger.Info($"local time: {Timestamp.MSToLocal(ts)}, count: {t.count}, amount: {t.amount}, volume: {t.vol}");
            }
        }
    }
}
