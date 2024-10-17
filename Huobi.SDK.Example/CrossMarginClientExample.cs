﻿using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Request.Margin;
using Huobi.SDK.Model.Response;

namespace Huobi.SDK.Example
{
    public class CrossMarginClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            TransferIn();

            TransferOut();

            GetLoanInfo();

            ApplyLoan();

            RepayLoan();

            GetLoanOrders();

            GetMarginAccount();

            GeneralRepay();

            GetRepayment();
        }

        private static void TransferIn()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.TransferIn("eos", "0.000001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.TransferOut("eos", "0.000001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.GetLoanInfo().Result;
            _logger.StopAndLog();

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
                                    AppLogger.Info($"Currency: {c.currency}, interest: {c.interestRate}," +
                                        $" min: {c.maxLoanAmt}, max: {c.maxLoanAmt}, loanable: {c.loanableAmt}");
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.ApplyLoan("eos", "0.001").Result;
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

        private static void RepayLoan()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.Repay("123", "0.001").Result;
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
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            GetRequest request = new GetRequest()
                .AddParam("sub-uid", Config.SubUserId);
            var response = marginClient.GetLoanOrders(request).Result;
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
                                    AppLogger.Info($"Loan order id: {o.id}, currency: {o.currency}, amount: {o.loanAmount}, state: {o.state}");
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

        private static void GetMarginAccount()
        {
            var marginClient = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var response = marginClient.GetMarginAccount(Config.SubUserId).Result;
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
                                    AppLogger.Info($"Account Id: {a.id}");
                                    if (a.list != null)
                                    {
                                        foreach (var c in a.list)
                                        {
                                            AppLogger.Info($"Currency: {c.currency}, balance: {c.balance}");
                                        }
                                    }
                                }
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

        private static void GeneralRepay()
        {
            var client = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            var request = new GeneralRepayRequest
            {
                accountId = Config.AccountId,
                amount = "10",
                currency = "htusdt"
            };

            var result = client.GeneralRepay(request).Result;
            if ((result.code == (int)ResponseCode.Success) && result.data != null)
            {
                AppLogger.Info($"General repay success, count: {result.data.Length}");
                foreach (var r in result.data)
                {
                    AppLogger.Info($"Repay id: {r.repayId}, time: {r.repayTime}");
                }
            }
            else
            {
                AppLogger.Error($"General repay error, code: {result.code}, message: {result.message}");
            }
        }

        private static void GetRepayment()
        {
            var client = new CrossMarginClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            var request = new GetRepaymentRequest
            {
                accountId = Config.AccountId,
                currency = "htusdt"
            };

            var result = client.GetRepayment(request).Result;
            if ((result.code == (int)ResponseCode.Success) && result.data != null)
            {
                AppLogger.Info($"Get repayment success, count: {result.data.Length}");
                foreach (var r in result.data)
                {
                    AppLogger.Info($"Repay id: {r.repayId}, time: {r.repayTime}, currency: {r.currency}, amount: {r.repaidAmount}");
                }
            }
            else
            {
                AppLogger.Error($"Get repayment error, code: {result.code}, message: {result.message}");
            }
        }
    }
}
