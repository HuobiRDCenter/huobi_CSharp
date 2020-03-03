using System;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class CrossMarginClientExample
    {
        public static void RunAll()
        {
            Config.LoadConfig();
            
            TransferIn();

            TransferOut();

            GetLoanInfo();

            ApplyLoan();

            RepayLoan();

            GetLoanOrders();

            GetMarginAccount();
        }

        private static void TransferIn()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.TransferIn("eos", "0.000001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.TransferOut("eos", "0.000001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.GetLoanInfo().Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            if (response.data != null)
                            {
                                foreach (var c in response.data)
                                {
                                    Console.WriteLine($"Currency: {c.currency}, interest: {c.interestRate}," +
                                        $" min: {c.maxLoanAmt}, max: {c.maxLoanAmt}, loanable: {c.loanableAmt}");
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.ApplyLoan("eos", "0.001").Result;
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

        private static void RepayLoan()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.Repay("123", "0.001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.GetLoanOrders().Result;
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
                                    Console.WriteLine($"Loan order id: {o.id}, currency: {o.currency}, amount: {o.loanAmount}, state: {o.state}");
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

        private static void GetMarginAccount()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey);

            var response = marginClient.GetMarginAccount().Result;
            if (response != null)
            {
                switch (response.status)
                {
                    case "ok":
                        {
                            if (response.data != null)
                            {
                                var a = response.data;
                                Console.WriteLine($"Account Id: {a.id}");
                                if (a.list != null)
                                {
                                    foreach (var c in a.list)
                                    {
                                        Console.WriteLine($"Currency: {c.currency}, balance: {c.balance}");
                                    }
                                }
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
