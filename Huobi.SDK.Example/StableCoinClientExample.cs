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
            var stableCoinClient = new StableCointClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = stableCoinClient.GetStableCoinAsync("tusd", "1000", "sell").Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            var d = result.data;
                            AppLogger.Info($"Get stable coin successfully, quoteId: {d.quoteId}, currency: {d.currency}, amount: {d.amount}, fee: {d.exchangeFee}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get stable coin fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void ExchangeStableCoin()
        {
            var stableCoinClient = new StableCointClient(Config.AccessKey, Config.SecretKey,Config.Sign);

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
