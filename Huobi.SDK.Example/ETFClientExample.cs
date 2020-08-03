using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    public class ETFClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetETFInfo();

            SwapETFIn();

            SwapETFOut();

            GetETFSwapHistory();
        }

        private static void GetETFInfo()
        {
            var etfClient = new ETFClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = etfClient.GetETFInfoAsync().Result;
            _logger.StopAndLog();

            if (response != null && response.data != null)
            {
                AppLogger.Info($"ETF name: {response.data.etfName}, purchase min amount: {response.data.purchaseMinAmount}");
                if (response.data.unitPrice != null)
                {
                    foreach (var p in response.data.unitPrice)
                    {
                        AppLogger.Info($"Currency: {p.currency}, amount: {p.amount}");
                    }
                }
            }
        }

        private static void SwapETFIn()
        {
            var etfClient = new ETFClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = etfClient.SwapETFInAsync(100).Result;
            _logger.StopAndLog();

            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    AppLogger.Info($"Swap in success: {message}");
                }
                else
                {
                    AppLogger.Info($"Swap in fail: {message}");
                }
            }
        }

        private static void SwapETFOut()
        {
            var etfClient = new ETFClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = etfClient.SwapETFOutAsync(100).Result;
            _logger.StopAndLog();

            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    AppLogger.Info($"Swap out success: {message}");
                }
                else
                {
                    AppLogger.Info($"Swap out fail: {message}");
                }
            }
        }

        private static void GetETFSwapHistory()
        {
            var etfClient = new ETFClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = etfClient.GetETFSwapHistory(0, 1).Result;
            _logger.StopAndLog();

            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    if (response.data != null)
                    {
                        foreach (var h in response.data)
                        {
                            AppLogger.Info($"Currency: {h.currency}, amount {h.amount}");
                        }
                        AppLogger.Info($"There are total {response.data.Length} ETF swap history");
                    }
                }
                else
                {
                    AppLogger.Info($"Get Swap history fail: {message}");
                }
            }
        }
    }
}
