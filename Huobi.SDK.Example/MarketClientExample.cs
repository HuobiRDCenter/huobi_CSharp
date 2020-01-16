using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class MarketClientExample
    {
        public static void RunAll()
        {
            GetCandlestick();

            GetLast24hCandlestickAskBid();

            GetLast24hCandlesticks();

            GetDepth();

            GetLastTrade();

            GetLastTrades();

            GetLast24Candlestick();
        }

        private static void GetCandlestick()
        {
            var marketClient = new MarketClient();

            var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt")
                .AddParam("period", "1min")
                .AddParam("size", "10");
            var getCResponse = marketClient.GetCandlestickAsync(reqParams).Result;
            if (getCResponse != null && getCResponse.data != null)
            {
                foreach (var c in getCResponse.data)
                {
                    Console.WriteLine($"local time: {Timestamp.SToLocal(c.id)}, count: {c.count}, amount: {c.amount}, volume: {c.vol}");
                }
                Console.WriteLine($"there are total {getCResponse.data.Length} candlesticks");
            }

        }

        private static void GetLast24hCandlestickAskBid()
        {
            var marketClient = new MarketClient();

            var getl24CABResponse = marketClient.GetLast24hCandlestickAskBidAsync("btcusdt").Result;
            if (getl24CABResponse != null && getl24CABResponse.tick != null)
            {
                var ts = getl24CABResponse.ts;
                var t = getl24CABResponse.tick;

                Console.WriteLine($"local time: {Timestamp.MSToLocal(ts)}, ask: [{t.ask[0]}, {t.ask[1]}], bid: [{t.bid[0]} {t.bid[1]}]");
            }
        }

        private static void GetLast24hCandlesticks()
        {
            var marketClient = new MarketClient();

            var getl24CsResponse = marketClient.GetLast24hCandlesticksAsync().Result;
            if (getl24CsResponse != null && getl24CsResponse.data != null)
            {
                foreach (var t in getl24CsResponse.data)
                {
                    Console.WriteLine($"symbol: {t.symbol}, count {t.count}, amount: {t.amount}, volume: {t.vol}");
                }
                Console.WriteLine($"There are total {getl24CsResponse.data.Length} candlesticks");

            }
        }

        private static void GetDepth()
        {
            var marketClient = new MarketClient();

            var depthReqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt")
                .AddParam("depth", "5")
                .AddParam("type", "step0");
            var getDepthResponse = marketClient.GetDepthAsync(depthReqParams).Result;
            if (getDepthResponse != null && getDepthResponse.tick != null)
            {
                var asks = getDepthResponse.tick.asks;
                if (asks != null)
                {
                    for (int i = asks.Length - 1; i >= 0; i--)
                    {
                        Console.WriteLine($"[{asks[i][0]}, {asks[i][1]}]");
                    }
                }
                Console.WriteLine($"----------");
                var bids = getDepthResponse.tick.bids;
                if (bids != null)
                {
                    for (int i = 0; i < bids.Length; i++)
                    {
                        Console.WriteLine($"[{bids[i][0]}, {bids[i][1]}]");
                    }
                }
            }
        }

        private static void GetLastTrade()
        {
            var marketClient = new MarketClient();

            var getLastTradeResponse = marketClient.GetLastTradeAsync("btcusdt").Result;
            if (getLastTradeResponse != null && getLastTradeResponse.tick != null)
            {
                var data = getLastTradeResponse.tick.data;
                if (data != null)
                {
                    foreach (var t in data)
                    {
                        Console.WriteLine($"singapore time: {Timestamp.MSToLocal(t.ts)}," +
                            $" trade-id: {t.tradeId}, amount: {t.amount}, price: {t.price}, direction: {t.direction}");
                    }
                    Console.WriteLine($"There are latest {data.Length} tradings");
                }
            }
        }

        private static void GetLastTrades()
        {
            var marketClient = new MarketClient();

            var getLastTradesResponse = marketClient.GetLastTradesAsync("btcusdt", 3).Result;
            if (getLastTradesResponse != null && getLastTradesResponse.data != null)
            {
                var data = getLastTradesResponse.data;
                foreach (var d in data)
                {
                    if (d.data != null)
                    {
                        foreach (var t in d.data)
                        {
                            Console.WriteLine($"singapore time: {Timestamp.MSToLocal(t.ts)}," +
                                $" trade-id: {t.tradeId}, amount: {t.amount}, price: {t.price}, direction: {t.direction}");
                        }
                        Console.WriteLine($"There are latest {d.data.Length} tradings");
                    }
                }
            }
        }

        private static void GetLast24Candlestick()
        {
            var marketClient = new MarketClient();

            var getLast24CResponse = marketClient.GetLast24hCandlestickAsync("btcusdt").Result;
            if (getLast24CResponse != null && getLast24CResponse.tick != null)
            {
                var ts = getLast24CResponse.ts;
                var t = getLast24CResponse.tick;
                Console.WriteLine($"local time: {Timestamp.MSToLocal(ts)}, count: {t.count}, amount: {t.amount}, volume: {t.vol}");
            }
        }
    }
}
