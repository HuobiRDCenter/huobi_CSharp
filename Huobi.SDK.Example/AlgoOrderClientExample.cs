using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Request.AlgoOrder;
using Huobi.SDK.Model.Response;

namespace Huobi.SDK.Example
{
    public class AlgoOrderClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            PlaceOrder();

            GetOpenOrders();

            CancelOrders();

            GetHistoryOrders();

            GetSpecificOrder();
        }

        private static void PlaceOrder()
        {
            var tradeClient = new AlgoOrderClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new PlaceOrderRequest
            {
                accountId = 11136102,
                orderSide = "buy",
                orderType = "limit",
                symbol = "htusdt",
                orderSize = "5",
                orderPrice = "2.1",
                stopPrice = "2",
                clientOrderId = "0922T1753"
            };

            var response = tradeClient.PlaceOrderAsync(request).Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                AppLogger.Info($"Place algo order successfully, client order id: {response.data.clientOrderId}");
            }
            else
            {
                AppLogger.Info($"Place algo order fail, error code: {response.code}, error message: {response.message}");
            }
        }

        private static void CancelOrders()
        {
            var tradeClient = new AlgoOrderClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new CancelOrdersRequest
            {
                clientOrderIds = new string[]{ "0922T1753" }
            };

            var response = tradeClient.CancelOrdersAsync(request).Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                foreach (string cid in response.data.accepted)
                {
                    AppLogger.Info($"Cancel algo order successfully, client order id: {cid}");
                }
                foreach (string cid in response.data.rejected)
                {
                    AppLogger.Info($"Cancel algo order fail, client order id: {cid}");
                }
            }
            else
            {
                AppLogger.Info($"Place algo order fail, error code: {response.code}, error message: {response.message}");
            }
        }

        private static void GetOpenOrders()
        {
            var client = new AlgoOrderClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "htusdt");
            var response = client.GetOpenOrdersAsync(request).Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                if (response.data != null)
                {
                    AppLogger.Info($"There are total {response.data.Length} open algo orders");
                    foreach (var o in response.data)
                    {
                        AppLogger.Info($"Algo order symbol: {o.symbol}, price: {o.orderPrice}, status: {o.orderStatus}");
                    }
                }
            }
            else
            {
                AppLogger.Info($"Get open algo orders fail, error code: {response.code}, error message: {response.message}");
            }
        }

        private static void GetHistoryOrders()
        {
            var client = new AlgoOrderClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbol", "htusdt")
                .AddParam("orderStatus", "canceled");
            var response = client.GetHistoryOrdersAsync(request).Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                if (response.data != null)
                {
                    AppLogger.Info($"There are total {response.data.Length} history algo orders");
                    foreach (var o in response.data)
                    {
                        AppLogger.Info($"Algo order client order id: {o.clientOrderId}, symbol: {o.symbol}, lastActTime: {o.lastActTime}");
                    }
                }
            }
            else
            {
                AppLogger.Info($"Get history algo orders fail, error code: {response.code}, error message: {response.message}");
            }
        }

        private static void GetSpecificOrder()
        {
            var client = new AlgoOrderClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = client.GetSpecificOrderAsync("0922T1653").Result;
            _logger.StopAndLog();

            if (response.code == (int)ResponseCode.Success)
            {
                if (response.data != null)
                {
                    var o = response.data;
                    AppLogger.Info($"Get algo order success, client order id: {o.clientOrderId}, symbol: {o.symbol}, lastActTime: {o.lastActTime}");
                }
            }
            else
            {
                AppLogger.Info($"Get algo order fail, error code: {response.code}, error message: {response.message}");
            }
        }
    }
}
