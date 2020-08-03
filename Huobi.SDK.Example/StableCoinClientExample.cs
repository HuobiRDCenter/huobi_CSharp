using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    public class StableCoinClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetStableCoin();

            ExchangeStableCoin();
        }

        private static void GetStableCoin()
        {
            var stableCoinClient = new StableCointClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = stableCoinClient.GetStableCoinAsync("usdt", "10", "sell").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Get stable coin successfully");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get stable coin fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void ExchangeStableCoin()
        {
            var stableCoinClient = new StableCointClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = stableCoinClient.ExchangeStableCoinAsync("123").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Exchange successfully");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Exchange fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }
    }
}
