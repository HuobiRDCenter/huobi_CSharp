using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
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

            GetAccountHistory();

            GetAccountLedger();

            TransferFromSpotToFuture();

            TransferFromFutureToSpot();

            TransferCurrencyFromMasterToSub();

            TransferCurrencyFromSubToMaster();

            GetSubuserAccountBalances();

            GetSubuserAccountBalance();

            LockSubUser();

            UnLockSubUser();
        }

        private static void GetAccountInfo()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

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
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

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

        private static void GetAccountHistory()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

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
            var client = new AccountClient(Config.AccessKey, Config.SecretKey);

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
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

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
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

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

        private static void TransferCurrencyFromMasterToSub()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.TransferCurrencyFromMasterToSubAsync(Config.SubUserId, "ht", 0.01m).Result;
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


        private static void TransferCurrencyFromSubToMaster()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.TransferCurrencyFromSubToMasterAsync(Config.SubUserId, "ht", 0.01m).Result;
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

        private static void GetSubuserAccountBalances()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.GetSubUserAccountBalancesAsync().Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                int availableCount = 0;
                foreach (var b in result.data)
                {
                    if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                    {
                        availableCount++;
                        AppLogger.Info($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                    }
                }
                AppLogger.Info($"There are total {result.data.Length} currencys and available {availableCount} currencys in this account");
            }
        }

        private static void GetSubuserAccountBalance()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.GetSubUserAccountBalanceAsync(Config.SubUserId).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                foreach (var a in result.data)
                {
                    int availableCount = 0;
                    AppLogger.Info($"account id: {a.id}, type: {a.type}");
                    foreach (var b in a.list)
                    {
                        if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                        {
                            availableCount++;
                            AppLogger.Info($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                        }
                    }
                    AppLogger.Info($"There are total {a.list.Length} accounts and available {availableCount} currencys in this account");
                }
                AppLogger.Info($"There are total {result.data.Length} accounts");
            }
        }

        private static void LockSubUser()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.LockSubUserAsync(Config.SubUserId).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Lock sub user ${result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    AppLogger.Info($"Lock sub user error: {result.code}");
                }
            }
        }

        private static void UnLockSubUser()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.UnlockSubUserAsync(Config.SubUserId).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Unlock sub user ${result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    AppLogger.Info($"Unlock sub user error: {result.code}");
                }
            }
        }
    }
}