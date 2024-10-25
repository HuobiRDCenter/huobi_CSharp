using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Request.Order;
using Huobi.SDK.Model.Response;

namespace Huobi.SDK.Example
{
    public class OrderClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
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
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
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
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        AppLogger.Info($"Place order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Place order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void PlaceOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
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
            _logger.StopAndLog();

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
                                    AppLogger.Info($"Place order successfully, order id: {r.orderId}");
                                }
                                else
                                {
                                    AppLogger.Info($"Place order fail, error code: {r.errorCode}, error message: {r.errorMessage}");
                                }
                            }
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Place multiple orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrderById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = tradeClient.CancelOrderByIdAsync("1", "BTC").Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        AppLogger.Info($"Cancel order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Cancel order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrderByClient()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = tradeClient.CancelOrderByClientOrderIdAsync("").Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        AppLogger.Info($"Cancel order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Cancel order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOpenOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("account-id", Config.AccountId);
            var response = tradeClient.GetOpenOrdersAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                AppLogger.Info($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}");  
                            }
                            AppLogger.Info($"There are total {response.data.Length} open orders");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Query open orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrdersByCriteria()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new CancelOrdersByCriteriaRequest
            {
                AccountId = Config.AccountId
            };
            var response = tradeClient.CancelOrdersByCriteriaAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var d = response.data;
                            AppLogger.Info($"Cancel success: {d.successCount}, fail: {d.failedCount}, next: {d.nextId}");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Cancel orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void CancelOrdersByIds()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            string[] orderIds = { "1", "2" };
            var request = new CancelOrdersByIdsRequest
            {
                OrderIds = orderIds
            };
            var response = tradeClient.CancelOrdersByIdsAsync(request).Result;
            _logger.StopAndLog();

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
                                    AppLogger.Info($"Cancel success: {s}");
                                }
                            }
                            if (response.data.failed != null)
                            {
                                foreach (var f in response.data.failed)
                                {
                                    string id = !string.IsNullOrWhiteSpace(f.orderId) ? f.orderId : f.clientOrderId;

                                    AppLogger.Info($"Cancel fail, id: {id}, error: {f.errorMessage}");
                                }
                            }
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Cancel orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOrderById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = tradeClient.GetOrderByIdAsync("1").Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var o = response.data;
                            AppLogger.Info($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}," +
                                $" filled amount: {o.filledAmount}, filled cash amount: {o.filledCashAmount}, filled fees: {o.filledFees}");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetOrderByClient()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("clientOrderId", "cid1234");

            var response = tradeClient.GetOrderByClientAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            var o = response.data;
                            AppLogger.Info($"Order symbol: {o.symbol}, price: {o.price}, amount: {o.amount}");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetMatchResultsById()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = tradeClient.GetMatchResultsByIdAsync("137534048832590").Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var r in response.data)
                            {
                                AppLogger.Info($"Match result symbol: {r.symbol}, amount: {r.filledAmount}, fee: {r.filledFees}, state: {r.feeDeductState}");
                            }
                            AppLogger.Info($"There are total {response.data.Length} match results");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get match result fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetHistoryOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "btcusdt")
                .AddParam("states", "canceled");
            var response = tradeClient.GetHistoryOrdersAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                AppLogger.Info($"Order symbol: {o.symbol}, amount: {o.amount}, state: {o.state}");
                            }
                            AppLogger.Info($"There are total {response.data.Length} history orders");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get history orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetLast48hOrders()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "btcusdt");
            var response = tradeClient.GetLast48hOrdersAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var o in response.data)
                            {
                                AppLogger.Info($"Order symbol: {o.symbol}, amount: {o.amount}, state: {o.state}");
                            }
                            AppLogger.Info($"There are total {response.data.Length} history orders");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get history orders fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetMatchResults()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "htusdt")
                .AddParam("start-date", "2020-11-02");
            var response = tradeClient.GetMatchResultsAsync(request).Result;
            _logger.StopAndLog();

            switch (response.status)
            {
                case "ok":
                    {
                        if (response.data != null)
                        {
                            foreach (var r in response.data)
                            {
                                AppLogger.Info($"Match result order id: {r.orderId}, symbol: {r.symbol}, price: {r.price}, amount: {r.filledAmount}, fee: {r.filledFees}, state: {r.feeDeductState}");
                            }
                            AppLogger.Info($"There are total {response.data.Length} match results");
                        }
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Get mattch result fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }

        private static void GetTransactFeeRate()
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbols", "btcusdt,eosht");
            var response = tradeClient.GetTransactFeeRateAsync(request).Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                if (response.data != null)
                {
                    foreach (var f in response.data)
                    {
                        AppLogger.Info($"Symbol: {f.symbol}, maker-taker fee: {f.makerFeeRate}-{f.takerFeeRate}");
                    }
                }
            }
            else
            {
                AppLogger.Info($"Get transact fee rate error: {response.message}");
            }
        }
    }
}
