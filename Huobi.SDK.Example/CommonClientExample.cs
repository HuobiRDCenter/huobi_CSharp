using System;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class CommonClientExample
    {
        public static void RunAll()
        {
            GetSymbols();

            GetCurrencys();

            GetCurrency();

            GetTimestamp();
        }

        private static void GetSymbols()
        {
            var client = new CommonClient();

            var symbolsResponse = client.GetSymbolsAsync().Result;
            if (symbolsResponse != null && symbolsResponse.status != null && symbolsResponse.status.Equals("ok"))
            {
                foreach (var d in symbolsResponse.data)
                {
                    Console.WriteLine($"{d.symbol}: {d.baseCurrency} {d.quoteCurrency}");
                }
                Console.WriteLine($"there are total {symbolsResponse.data.Length} symbols");
            }
        }

        private static void GetCurrencys()
        {
            var client = new CommonClient();

            var currencysResponse = client.GetCurrencysAsync().Result;
            if (currencysResponse != null && currencysResponse.data != null)
            {
                foreach (var d in currencysResponse.data)
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine($"there are total {currencysResponse.data.Length} currencys");
            }
        }

        private static void GetCurrency()
        {
            var client = new CommonClient();

            var currencyResponse = client.GetCurrencyAsync("", false).Result;
            if (currencyResponse != null)
            {
                if (currencyResponse.code == 200)
                {
                    foreach (var d in currencyResponse.data)
                    {
                        Console.WriteLine($"Currency: {d.currency}");
                        foreach (var c in d.chains)
                        {
                            Console.WriteLine($"Chain name: {c.chain}, base chain: {c.baseChain}, base chain protocol: {c.baseChainProtocol}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(currencyResponse.message);
                }
            }
        }

        private static void GetTimestamp()
        {
            var client = new CommonClient();

            var timestampResponse = client.GetTimestampAsync().Result;
            Console.WriteLine($"timestamp (ms): {timestampResponse.data}");
            Console.WriteLine($"Local time: {Timestamp.MSToLocal(timestampResponse.data)}");
        }
    }
}
