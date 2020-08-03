using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Response;

namespace Huobi.SDK.Example
{
    public class CommonClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetSystemStatus();

            GetSymbols();

            GetCurrencys();

            GetCurrency();

            GetTimestamp();
        }

        private static void GetSystemStatus()
        {
            var client = new CommonClient();

            _logger.Start();
            string result = client.GetSystemStatus().Result;
            _logger.StopAndLog();

            AppLogger.Info($"Get system status: {result}");
        }

        private static void GetSymbols()
        {
            var client = new CommonClient();

            _logger.Start();
            var symbolsResponse = client.GetSymbolsAsync().Result;
            _logger.StopAndLog();

            if (symbolsResponse != null && symbolsResponse.status != null && symbolsResponse.status.Equals("ok"))
            {
                foreach (var d in symbolsResponse.data)
                {
                    AppLogger.Info($"{d.symbol}: {d.baseCurrency} {d.quoteCurrency}");
                }
                AppLogger.Info($"there are total {symbolsResponse.data.Length} symbols");
            }
        }

        private static void GetCurrencys()
        {
            var client = new CommonClient();

            _logger.Start();
            var currencysResponse = client.GetCurrencysAsync().Result;
            _logger.StopAndLog();

            if (currencysResponse != null && currencysResponse.data != null)
            {
                foreach (var d in currencysResponse.data)
                {
                    AppLogger.Info(d);
                }
                AppLogger.Info($"there are total {currencysResponse.data.Length} currencys");
            }
        }

        private static void GetCurrency()
        {
            var client = new CommonClient();

            _logger.Start();
            var currencyResponse = client.GetCurrencyAsync("", false).Result;
            _logger.StopAndLog();

            if (currencyResponse != null)
            {
                if (currencyResponse.code == (int)ResponseCode.Success)
                {
                    foreach (var d in currencyResponse.data)
                    {
                        AppLogger.Info($"Currency: {d.currency}");
                        foreach (var c in d.chains)
                        {
                            AppLogger.Info($"Chain name: {c.chain}, base chain: {c.baseChain}, base chain protocol: {c.baseChainProtocol}");
                        }
                    }
                }
                else
                {
                    AppLogger.Info(currencyResponse.message);
                }
            }
        }

        private static void GetTimestamp()
        {
            var client = new CommonClient();

            _logger.Start();
            var timestampResponse = client.GetTimestampAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"timestamp (ms): {timestampResponse.data}");
            AppLogger.Info($"Local time: {Timestamp.MSToLocal(timestampResponse.data)}");
        }
    }
}
