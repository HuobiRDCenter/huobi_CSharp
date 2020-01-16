using System;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class ETFClientExample
    {
        public static void RunAll()
        {
            APIKey.LoadAPIKey();

            GetETFInfo();

            SwapETFIn();

            SwapETFOut();

            GetETFSwapHistory();
        }

        private static void GetETFInfo()
        {
            var etfClient = new ETFClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = etfClient.GetETFInfoAsync().Result;
            if (response != null && response.data != null)
            {
                Console.WriteLine($"ETF name: {response.data.etfName}, purchase min amount: {response.data.purchaseMinAmount}");
                if (response.data.unitPrice != null)
                {
                    foreach (var p in response.data.unitPrice)
                    {
                        Console.WriteLine($"Currency: {p.currency}, amount: {p.amount}");
                    }
                }
            }
        }

        private static void SwapETFIn()
        {
            var etfClient = new ETFClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = etfClient.SwapETFInAsync(100).Result;
            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    Console.WriteLine($"Swap in success: {message}");
                }
                else
                {
                    Console.WriteLine($"Swap in fail: {message}");
                }
            }
        }

        private static void SwapETFOut()
        {
            var etfClient = new ETFClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = etfClient.SwapETFOutAsync(100).Result;
            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    Console.WriteLine($"Swap in success: {message}");
                }
                else
                {
                    Console.WriteLine($"Swap in fail: {message}");
                }
            }
        }

        private static void GetETFSwapHistory()
        {
            var etfClient = new ETFClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = etfClient.GetETFSwapHistory(0, 1).Result;
            if (response != null)
            {
                string message = string.IsNullOrEmpty(response.message) ? "" : response.message;

                if (response.success)
                {
                    if (response.data != null)
                    {
                        foreach (var h in response.data)
                        {
                            Console.WriteLine($"Currency: {h.currency}, amount {h.amount}");
                        }
                        Console.WriteLine($"There are total {response.data.Length} ETF swap history");
                    }
                }
                else
                {
                    Console.WriteLine($"Get Swap history fail: {message}");
                }
            }
        }
    }
}
