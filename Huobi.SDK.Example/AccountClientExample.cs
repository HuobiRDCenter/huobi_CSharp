using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Request.Account;
using Huobi.SDK.Model.Response;

namespace Huobi.SDK.Example
{
    public class AccountClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetAccountInfo();

            GetAccountBalance();

            GetAccountAssetValuation();

            TransferAccount();

            GetAccountHistory();

            GetAccountLedger();

            TransferFromSpotToFuture();

            TransferFromFutureToSpot();

            GetPointBalance();

            TransferPoint();
        }

        private static void GetAccountInfo()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.GetAccountInfoAsync().Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                AppLogger.Info($"Get account info, count={result.data.Length}");
                foreach (var a in result.data)
                {
                    AppLogger.Info($"account id: {a.id}, type: {a.type}, state: {a.state}");
                }
            }
        }

        private static void GetAccountBalance()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.GetAccountBalanceAsync(Config.AccountId).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            if (result.data != null && result.data.list != null)
                            {
                                AppLogger.Info($"Get account balance, count={result.data.list.Length}");
                                int availableCount = 0;
                                foreach (var b in result.data.list)
                                {
                                    if (Math.Abs(float.Parse(b.balance)) > 0.0000001)
                                    {
                                        availableCount++;
                                        AppLogger.Info($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                                    }
                                }
                                AppLogger.Info($"There are total {result.data.list.Length} currencys and available {availableCount} currencys in this account");
                            }
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetAccountAssetValuation()
        {
            var client = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);
            string currency = "USD";
            _logger.Start();
            var result = client.GetAccountAssetValuationAsync("spot", currency).Result;
            _logger.StopAndLog();

            if (result != null && result.code == 200 && result.data != null)
            {
                AppLogger.Info($"Get account asset valuation, balance: {result.data.balance} {currency}, time: {result.data.timestamp}");
            }
            else
            {
                AppLogger.Error($"Get account asset valuation error, code: {result.code}, message: {result.message}");
            }
        }

        private static void TransferAccount()
        {
            var client = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);
            var request = new TransferAccountRequest
            {
                fromUser = 125753978,
                fromAccountType = "spot",
                fromAccount = 11136102,
                toUser = 128654510,
                toAccountType = "spot",
                toAccount = 12825690,
                currency = "ht",
                amount = "0.1"
            };

            var result = client.TransferAccountAsync(request).Result;
            if (result != null)
            {
                if (result.status == "ok" && result.data != null)
                {
                    AppLogger.Info($"Transfer account success, id: {result.data.transactId}, time: {result.data.transactTime}");
                }
                else
                {
                    AppLogger.Error($"Transfer account error, code: {result.errCode}, message: {result.errMessage}");
                }
            }
        }

        private static void GetAccountHistory()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("account-id", Config.AccountId);
            var result = accountClient.GetAccountHistoryAsync(request).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Get account history, count={result.data.Length}");
                            foreach (var h in result.data)
                            {
                                AppLogger.Info($"currency: {h.currency}, amount: {h.transactAmt}, type: {h.transactType}, time: {h.transactTime}");
                            }
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Get fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetAccountLedger()
        {
            var client = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            GetRequest request = new GetRequest()
                .AddParam("accountId", Config.AccountId);
            var result = client.GetAccountLedgerAsync(request).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Get account ledger, count={result.data.Length}");
                    foreach (var l in result.data)
                    {
                        AppLogger.Info($"Get account ledger, accountId: {l.accountId}, currency: {l.currency}, amount: {l.transactAmt}, transferer: {l.transferer}, transferee: {l.transferee}");
                    }
                }
                else
                {
                    AppLogger.Info($"Get account ledger error: {result.message}");
                }
            }
        }

        private static void TransferFromSpotToFuture()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.TransferFromSpotToFutureAsync("ht", 1).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Transfer successfully, trade id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Transfer fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferFromFutureToSpot()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.TransferFromFutureToSpotAsync("ht", 1).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            AppLogger.Info($"Transfer successfully, trade id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            AppLogger.Info($"Transfer fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetPointBalance()
        {
            var client = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = client.GetPointBalanceAsync().Result;
            _logger.StopAndLog();

            if (result != null && result.code == 200)
            {
                AppLogger.Info($"Get point balance, account id: {result.data.accountId}, status: {result.data.accountStatus}, balance: {result.data.acctBalance}");
                if (result.data.groupIds != null)
                {
                    AppLogger.Info($"Get point balance group, count={result.data.groupIds.Length}");
                    foreach (var a in result.data.groupIds)
                    {
                        AppLogger.Info($"group id: {a.groupId}, expiry: {a.expiryDate}, remainAmt: {a.remainAmt}");
                    }
                }
            }
        }

        private static void TransferPoint()
        {
            var client = new AccountClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            var request = new TransferPointRequest
            {
                fromUid = "125753978",
                toUid = "128654685",
                groupId = 0,
                amount = "0"
            };

            _logger.Start();
            var result = client.TransferPointAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.code == 200 && result.data != null)
            {
                AppLogger.Info($"Transfer point success, transact Id: {result.data.transactId}, time: {result.data.transactTime}");
            }
            else
            {
                AppLogger.Error($"Transfer point error, code: {result.code}, message: {result.message}");
            }
        }
    }
}