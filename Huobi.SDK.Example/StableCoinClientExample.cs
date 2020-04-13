using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Log;

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
                            Console.WriteLine($"Get stable coin successfully");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get stable coin fail, error code: {response.errorCode}, error message: {response.errorMessage}");
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
                            Console.WriteLine($"Exchange successfully");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Exchange fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }
    }
}
