﻿using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Request;

namespace Huobi.SDK.Example
{
    public class OrderClientExample
    {
        public static void RunAll()
        {
            APIKey.LoadAPIKey();

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

            GetFee();
        }

        private static void PlaceOrder()
        {
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var request = new PlaceOrderRequest
            {
                AccountId = APIKey.AccountId,
                type = "buy-limit",
                symbol = "btcusdt",
                amount = "1",
                price = "1.1"
            };

            var response = tradeClient.PlaceOrderAsync(request).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        Console.WriteLine($"Place order successfully, trade id: {response.data}");
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var request = new PlaceOrderRequest
            {
                AccountId = "1",
                type = "buy-limit"
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
                                    Console.WriteLine($"order id: {r.orderId}");
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("account-id", APIKey.AccountId);
            var response = tradeClient.GetOpenOrdersAsync(reqParams).Result;
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var bclbaRequest = new BatchCancelOrdersByAccountIdRequest
            {
                AccountId = APIKey.AccountId
            };
            var response = tradeClient.CancelOrdersByCriteriaAsync(bclbaRequest).Result;
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            string[] orderIds = { "1", "2" };
            var request = new BatchCancelOrdersByOrderIdRequest
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
                                    string id = (f.orderId != 0) ? f.orderId.ToString() : f.clientOrderId;

                                    Console.WriteLine($"Cancel fail, id: {f.clientOrderId}, error: {f.errorMessage}");
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = tradeClient.GetOrderByIdAsync("1").Result;
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

        private static void GetOrderByClient()
        {
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);
            var reqParams = new RequestParammeters()
                .AddParam("clientOrderId", "cid1234");

            var response = tradeClient.GetOrderByClientAsync(reqParams).Result;
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

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
                        Console.WriteLine($"Get mattch result fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetHistoryOrders()
        {
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt")
                .AddParam("states", "canceled");
            var response = tradeClient.GetHistoryOrdersAsync(reqParams).Result;
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt");
            var response = tradeClient.GetLast48hOrdersAsync(reqParams).Result;
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
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("symbol", "btcusdt");
            var response = tradeClient.GetMatchResultsAsync(reqParams).Result;
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

        private static void GetFee()
        {
            var tradeClient = new OrderClient(APIKey.AccessKey, APIKey.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("symbols", "btcusdt, eosht");
            var response = tradeClient.GetFeeAsync(reqParams).Result;
            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var f in response.data)
                            {
                                Console.WriteLine($"Symbol: {f.symbol}, maker fee: {f.makerFee}, taker fee: {f.takerFee}");
                            }
                        }
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine($"Get fee fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }
    }
}