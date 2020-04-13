using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Log;
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
                foreach (var a in result.data)
                {
                    Console.WriteLine($"account id: {a.id}, type: {a.type}, state: {a.state}");
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
                                int availableCount = 0;
                                foreach (var b in result.data.list)
                                {
                                    if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                                    {
                                        availableCount++;
                                        Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                                    }
                                }
                                Console.WriteLine($"There are total {result.data.list.Length} currencys and available {availableCount} currencys in this account");
                            }
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get fail, error code: {result.errorCode}, error message: {result.errorMessage}");
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
                            foreach (var h in result.data)
                            {
                                Console.WriteLine($"currency: {h.currency}, amount: {h.transactAmt}, type: {h.transactType}, time: {h.transactTime}");
                            }
                            Console.WriteLine($"There are total {result.data.Length} transactions");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get fail, error code: {result.errorCode}, error message: {result.errorMessage}");
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
                    foreach (var l in result.data)
                    {
                        Console.WriteLine($"Get account ledger, accountId: {l.accountId}, currency: {l.currency}, amount: {l.transactAmt}, transferer: {l.transferer}, transferee: {l.transferee}");
                    }
                }
                else
                {
                    Console.WriteLine($"Get account ledger error: {result.message}");
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
                            Console.WriteLine($"Transfer successfully, trade id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {result.errorCode}, error message: {result.errorMessage}");
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
                            Console.WriteLine($"Transfer successfully, trade id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferCurrencyFromMasterToSub()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = accountClient.TransferCurrencyFromMasterToSubAsync(Config.SubUserId, "ht", 1).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, trade id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {result.errorCode}, error message: {result.errorMessage}");
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
                        Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                    }
                }
                Console.WriteLine($"There are total {result.data.Length} currencys and available {availableCount} currencys in this account");
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
                    Console.WriteLine($"account id: {a.id}, type: {a.type}");
                    foreach (var b in a.list)
                    {
                        if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                        {
                            availableCount++;
                            Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                        }
                    }
                    Console.WriteLine($"There are total {a.list.Length} accounts and available {availableCount} currencys in this account");
                }
                Console.WriteLine($"There are total {result.data.Length} accounts");
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
                    Console.WriteLine($"Lock sub user ${result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    Console.WriteLine($"Lock sub user error: {result.code}");
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
                    Console.WriteLine($"Unlock sub user ${result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    Console.WriteLine($"Unlock sub user error: {result.code}");
                }
            }
        }
    }
}