using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class IsolatedMarginClientExample
    {
        public static void RunAll()
        {
            APIKey.LoadAPIKey();

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
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.TransferInAsync("eosht", "eos", "0.000001").Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, transfer id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferOut()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.TransferOutAsync("eosht", "eos", "0.000001").Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, transfer id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanInfo()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.GetLoanInfoAsync("btcusdt").Result;
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
                                        Console.WriteLine($"Loan info for symbol: {d.symbol}");
                                        foreach (var c in d.currencies)
                                        {
                                            Console.WriteLine($"Currency: {c.currency}, interest: {c.interestRate}," +
                                                $" min: {c.maxLoanAmt}, max: {c.maxLoanAmt}, loanable: {c.loanableAmt}");
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get loan info fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void ApplyLoan()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.ApplyLoanAsync("eosht", "eos", "0.001").Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Apply successfully, margin order id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Apply fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void Repay()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.RepayAsync("123", "0.001").Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Repay successfully, margin order id: {response.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Repay fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanOrders()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);
            var reqParams = new RequestParammeters()
                .AddParam("symbols", "btcusdt");

            var response = marginClient.GetLoanOrdersAsync(reqParams).Result;
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
                                    Console.WriteLine($"Loan order id: {o.id}, symbol: {o.symbol}, currency: {o.currency}, state: {o.state}");
                                }
                                Console.WriteLine($"There are total {response.data.Length} loan orders");
                            }
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get loan order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetLoanAccount()
        {
            var marginClient = new IsolatedMarginClient(APIKey.AccessKey, APIKey.SecretKey);

            var response = marginClient.GetMarginAccountAsync("btcusdt",null).Result;
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
                                    Console.WriteLine($"Symbol: {a.symbol}");
                                    if (a.list != null)
                                    {
                                        foreach (var c in a.list)
                                        {
                                            Console.WriteLine($"Currency: {c.currency}, balance: {c.balance}");
                                        }
                                    }
                                }
                                Console.WriteLine($"There are total {response.data.Length} margin accounts");
                            }
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get margin account fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                            break;
                        }
                }
            }
        }
    }
}
