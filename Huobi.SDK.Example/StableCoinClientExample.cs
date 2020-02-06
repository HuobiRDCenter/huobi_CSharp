using System;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class StableCoinClientExample
    {
        public static void RunAll()
        {
            Config.LoadConfig();

            GetStableCoin();

            ExchangeStableCoin();
        }

        private static void GetStableCoin()
        {
            var stableCoinClient = new StableCointClient(Config.AccessKey, Config.SecretKey);

            var response = stableCoinClient.GetStableCoinAsync("usdt", "10", "sell").Result;
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

            var response = stableCoinClient.ExchangeStableCoinAsync("123").Result;
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
