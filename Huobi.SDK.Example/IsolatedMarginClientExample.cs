using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    public class IsolatedMarginClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            TransferIn();

            TransferOut();

            GetLoanInfo();

            ApplyLoan();

            Repay();

            GetLoanOrders();

            GetLoanAccount();
        }

        private static void TransferIn()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.TransferInAsync("eosht", "eos", "0.01").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Transfer successfully, transfer id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Transfer fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferOut()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.TransferOutAsync("eosht", "eos", "0.01").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Transfer successfully, transfer id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Transfer fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanInfo()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.GetLoanInfoAsync("btcusdt").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            if (response.data != null)
                            {
                                foreach (var d in response.data)
                                {
                                    if (d.currencies != null)
                                    {
                                        AppLogger.Info($"Loan info for symbol: {d.symbol}");
                                        foreach (var c in d.currencies)
                                        {
                                            AppLogger.Info($"Currency: {c.currency}, interest: {c.interestRate}," +
                                                $" min: {c.maxLoanAmt}, max: {c.maxLoanAmt}, loanable: {c.loanableAmt}");
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get loan info fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void ApplyLoan()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.ApplyLoanAsync("eosht", "eos", "0.01").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Apply successfully, margin order id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Apply fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void Repay()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.RepayAsync("123", "0.01").Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Repay successfully, margin order id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Repay fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanOrders()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("symbols", "btcusdt");

            var response = marginClient.GetLoanOrdersAsync(request).Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            if (response.data != null)
                            {
                                foreach (var o in response.data)
                                {
                                    AppLogger.Info($"Loan order id: {o.id}, symbol: {o.symbol}, currency: {o.currency}, amount: {o.loanAmount}, state: {o.state}");
                                }
                                AppLogger.Info($"There are total {response.data.Length} loan orders");
                            }
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get loan order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanAccount()
        {
            var marginClient = new IsolatedMarginClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var response = marginClient.GetMarginAccountAsync("btcusdt", null).Result;
            _logger.StopAndLog();

            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            if (response.data != null)
                            {
                                foreach (var a in response.data)
                                {
                                    AppLogger.Info($"Account Id: {a.id}, Symbol: {a.symbol}");
                                    if (a.list != null)
                                    {
                                        foreach (var c in a.list)
                                        {
                                            AppLogger.Info($"Currency: {c.currency}, balance: {c.balance}");
                                        }
                                    }
                                }
                                AppLogger.Info($"There are total {response.data.Length} margin accounts");
                            }
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get margin account fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }
    }
}
