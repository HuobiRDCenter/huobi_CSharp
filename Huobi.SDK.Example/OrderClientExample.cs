using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Request;

namespace Huobi.SDK.Example
{
    public class OrderClientExample
    {
        public static void RunAll()
        {
            Config.LoadConfig();

            PlaceOrder();

            PlaceOrders();
            
            CancelOrderById();

            CancelOrderByClient();
            
            GetOpenOrders();

            CancelOrdersByCriteria();
            
            CancelOrdersByIds();
            
            GetHistoryOrders();
            
            GetOrderById();
            
            GetOrderByClient();
            
            GetMatchResultsById();
            
            GetHistoryOrders();

            GetLast48hOrders();

            GetMatchResults();

            GetTransactFeeRate();
        }

        private static void PlaceOrder()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new PlaceOrderRequest
            {
                AccountId = Config.AccountId,
                type = "buy-limit",
                symbol = "btcusdt",
                source = "spot-api",
                amount = "1",
                price = "1.1"
            };

            var response = tradeClient.PlaceOrderAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        Console.WriteLine($"Place order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Place order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void PlaceOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new PlaceOrderRequest
            {
                AccountId = Config.AccountId,
                type = "buy-limit",
                symbol = "btcusdt",
                source = "spot-api",
                amount = "1",
                price = "1.1"
            };
            PlaceOrderRequest[] requests = { request, request };
            var response = tradeClient.PlaceOrdersAsync(requests).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var r in response.data)
                            {
                                if (r.orderId != 0)
                                {
                                    Console.WriteLine($"Place order successfully, order id: {r.orderId}");
                                }
                                else
                                {
                                    Console.WriteLine($"Place order fail, error code: {r.errorCode}, error message: {r.errorMessage}");
                                }
                            }
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Place multiple orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrderById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var response = tradeClient.CancelOrderByIdAsync("1").Result;
            switch (response.status)
            {
                case "ok":
                    {
                        Console.WriteLine($"Cancel order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Cancel order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrderByClient()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var response = tradeClient.CancelOrderByClientOrderIdAsync("").Result;
            switch (response.status)
            {
                case "ok":
                    {
                        Console.WriteLine($"Cancel order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Cancel order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOpenOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("account-id", Config.AccountId);
            var response = tradeClient.GetOpenOrdersAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                Console.WriteLine($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}");  
                            }
                            Console.WriteLine($"There are total {response.data.Length} open orders");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Query open orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrdersByCriteria()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new CancelOrdersByCriteriaRequest
            {
                AccountId = Config.AccountId
            };
            var response = tradeClient.CancelOrdersByCriteriaAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var d = response.data;
                            Console.WriteLine($"Cancel success: {d.successCount}, fail: {d.failedCount}, next: {d.nextId}");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Cancel orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrdersByIds()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            string[] orderIds = { "1", "2" };
            var request = new CancelOrdersByIdsRequest
            {
                OrderIds = orderIds
            };
            var response = tradeClient.CancelOrdersByIdsAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            if (response.data.success != null)
                            {
                                foreach (string s in response.data.success)
                                {
                                    Console.WriteLine($"Cancel success: {s}");
                                }
                            }
                            if (response.data.failed != null)
                            {
                                foreach (var f in response.data.failed)
                                {
                                    string id = !string.IsNullOrWhiteSpace(f.orderId) ? f.orderId : f.clientOrderId;

                                    Console.WriteLine($"Cancel fail, id: {id}, error: {f.errorMessage}");
                                }
                            }
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Cancel orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOrderById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var response = tradeClient.GetOrderByIdAsync("1").Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var o = response.data;
                            Console.WriteLine($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}," +
                                $" filled amount: {o.filledAmount}, filled cash amount: {o.filledCashAmount}, filled fees: {o.filledFees}");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOrderByClient()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);
            var request = new GetRequest()
                .AddParam("clientOrderId", "cid1234");

            var response = tradeClient.GetOrderByClientAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var o = response.data;
                            Console.WriteLine($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetMatchResultsById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var response = tradeClient.GetMatchResultsByIdAsync("63403286375").Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var r in response.data)
                            {
                                Console.WriteLine($"Match result symbol: {r.symbol}, amount: {r.filledAmount}, fee: {r.filledFees}");
                            }
                            Console.WriteLine($"There are total {response.data.Length} match results");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get match result fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetHistoryOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("symbol", "btcusdt")
                .AddParam("states", "canceled");
            var response = tradeClient.GetHistoryOrdersAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                Console.WriteLine($"Order symbol: {o.symbol}, amount: {o.amount}, state: {o.state}");
                            }
                            Console.WriteLine($"There are total {response.data.Length} history orders");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get history orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetLast48hOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("symbol", "btcusdt");
            var response = tradeClient.GetLast48hOrdersAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                Console.WriteLine($"Order symbol: {o.symbol}, amount: {o.amount}, state: {o.state}");
                            }
                            Console.WriteLine($"There are total {response.data.Length} history orders");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get history orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetMatchResults()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("symbol", "btcusdt");
            var response = tradeClient.GetMatchResultsAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var r in response.data)
                            {
                                Console.WriteLine($"Match result symbol: {r.symbol}, amount: {r.filledAmount}, fee: {r.filledFees}");
                            }
                            Console.WriteLine($"There are total {response.data.Length} match results");
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get mattch result fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetTransactFeeRate()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("symbols", "btcusdt,eosht");
            var response = tradeClient.GetTransactFeeRateAsync(request).Result;
            if (response.code == 200)
            {
                if (response.data != null)
                {
                    foreach (var f in response.data)
                    {
                        Console.WriteLine($"Symbol: {f.symbol}, maker-taker fee: {f.makerFeeRate}-{f.takerFeeRate}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Get transact fee rate error: {response.message}");
            }
        }
    }
}
