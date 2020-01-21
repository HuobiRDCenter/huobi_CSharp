using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response.Market;

namespace Huobi.SDK.Example
{
    public class MarketWebSocketClientExample
    {
        public static void RunAll()
        {
            ReqAndSubscribeCandlestick();
            
            ReqAndSubscribeDepth();
            
            ReqAndSubscribeMBP();
            
            SubscribeBBO();

            ReqAndSubscribeTrade();

            ReqAndSubscribeLast24Candlestick();
        }

        private static void ReqAndSubscribeCandlestick()
        {
            // Initialize a new instance
            var client = new CandlestickWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt", "1min");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeCandlestickResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null) // Parse subscription data
                    {
                        Console.WriteLine($"id: {response.tick.id}, count: {response.tick.count}, vol: {response.tick.vol}");
                    }
                    else if (response.data != null) // Parse request data
                    {
                        foreach (var t in response.data)
                        {
                            Console.WriteLine($"id: {t.id}, count: {t.count}, vol: {t.vol}");
                        }
                        Console.WriteLine($"There are total {response.data.Length} ticks");
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();            

            // Request full data
            client.Req("btcusdt", "1min", 1569361140, 1569366420);

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt", "1min");

            // Delete handler
            //client.OnResponseReceived -= Client_OnResponseReceived;
            client.Disconnect();
        }

        private static void ReqAndSubscribeDepth()
        {
            var client = new DepthWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt", "step4");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeDepthResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null) // Parse subscription data
                    {
                        if (response.tick.asks != null)
                        {
                            var asks = response.tick.asks;
                            for (int i = asks.Length-1; i >= 0; i--)
                            {
                                Console.WriteLine($"[{asks[i][0]} {asks[i][1]}]");
                            }
                        }
                        Console.WriteLine("------");
                        if (response.tick.bids != null)
                        {
                            var bids = response.tick.bids;
                            for (int i = 0; i < bids.Length; i++)
                            {
                                Console.WriteLine($"[{bids[i][0]} {bids[i][1]}]");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (response.data != null) // Parse request data
                    {
                        if (response.data.asks != null)
                        {
                            var asks = response.data.asks;
                            for (int i = asks.Length - 1; i >= 0; i--)
                            {
                                Console.WriteLine($"[{asks[i][0]} {asks[i][1]}]");
                            }
                        }
                        Console.WriteLine("------");
                        if (response.data.bids != null)
                        {
                            var bids = response.data.bids;
                            for (int i = 0; i < bids.Length; i++)
                            {
                                Console.WriteLine($"[{bids[i][0]} {bids[i][1]}]");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            // Request full data
            client.Req("btcusdt", "step4");

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt", "step4");

            // Delete handler
            client.OnResponseReceived -= Client_OnResponseReceived;
        }

        private static void ReqAndSubscribeMBP()
        {
            var client = new MarketByPriceWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeMarketByPriceResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null) // Parse subscription data
                    {
                        if (response.tick.asks != null)
                        {
                            var asks = response.tick.asks;
                            for (int i = asks.Length - 1; i >= 0; i--)
                            {
                                Console.WriteLine($"[{asks[i][0]} {asks[i][1]}]");
                            }
                        }
                        Console.WriteLine("------");
                        if (response.tick.bids != null)
                        {
                            var bids = response.tick.bids;
                            for (int i = 0; i < bids.Length; i++)
                            {
                                Console.WriteLine($"[{bids[i][0]} {bids[i][1]}]");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (response.data != null) // Parse request data
                    {
                        if (response.data.asks != null)
                        {
                            var asks = response.data.asks;
                            for (int i = asks.Length - 1; i >= 0; i--)
                            {
                                Console.WriteLine($"[{asks[i][0]} {asks[i][1]}]");
                            }
                        }
                        Console.WriteLine("------");
                        if (response.data.bids != null)
                        {
                            var bids = response.data.bids;
                            for (int i = 0; i < bids.Length; i++)
                            {
                                Console.WriteLine($"[{bids[i][0]} {bids[i][1]}]");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            // Request full data
            client.Req("btcusdt");

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnResponseReceived -= Client_OnResponseReceived;
        }

        private static void SubscribeBBO()
        {
            // Initialize a new instance
            var client = new BestBidOfferWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeBestBidOfferResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null) // Parse subscription data
                    {
                        var t = response.tick;
                        Console.WriteLine($"id: {t.symbol}, ask: [{t.ask}, {t.askSize}], bid: [{t.bid}, {t.bidSize}]");
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnResponseReceived -= Client_OnResponseReceived;
        }

        private static void ReqAndSubscribeTrade()
        {
            // Initialize a new instance
            var client = new TradeWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeTradeResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null && response.tick.data != null) // Parse subscription data
                    {
                        foreach (var t in response.tick.data)
                        {
                            Console.WriteLine($"tradeid: {t.tradeid}, direction: {t.direction}, [{t.price}, {t.amount}]");
                        }
                    }
                    else if (response.data != null) // Parse request data
                    {
                        foreach (var t in response.data)
                        {
                            Console.WriteLine($"tradeid: {t.tradeid}, direction: {t.direction}, [{t.price}, {t.amount}]");
                        }
                        Console.WriteLine($"There are total {response.data.Length} trades");
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            // Request full data
            client.Req("btcusdt");
            
            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnResponseReceived -= Client_OnResponseReceived;
        }

        private static void ReqAndSubscribeLast24Candlestick()
        {
            // Initialize a new instance
            var client = new Last24hCandlestickWebSocketClient();

            // Add connection open handler
            client.OnConnectionOpen += Client_OnConnectionOpen;
            void Client_OnConnectionOpen()
            {
                // Subscribe the specific topic
                client.Subscribe("btcusdt");

                Console.WriteLine("Subscribed");
            }

            // Add the response receive handler
            client.OnResponseReceived += Client_OnResponseReceived;
            void Client_OnResponseReceived(SubscribeLast24hCandlestickResponse response)
            {
                if (response != null)
                {
                    if (response.tick != null) // Parse subscription data
                    {
                        Console.WriteLine($"id: {response.tick.id}, count: {response.tick.count}, vol: {response.tick.vol}");
                    }
                    else if (response.data != null) // Parse request data
                    {
                        Console.WriteLine($"id: {response.data.id}, count: {response.data.count}, vol: {response.data.vol}");
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            // Request full data
            client.Req("btcusdt");

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnResponseReceived -= Client_OnResponseReceived;
        }
    }
}
