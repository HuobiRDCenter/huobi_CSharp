using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Request.SubUser;
using Huobi.SDK.Model.Response;
using static Huobi.SDK.Model.Request.SubUser.CreateSubUserRequest;

namespace Huobi.SDK.Example
{
    public class SubUserClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetUID();

            CreateSubUser();

            LockSubUser();

            UnLockSubUser();

            TransferCurrencyFromMasterToSub();

            TransferCurrencyFromSubToMaster();

            GetSubuserAccountBalances();

            GetSubuserAccountBalance();

            GetSubUserDepositAddress();

            GetSubUserDepositHistory();
        }

        private static void GetUID()
        {
            var client = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            var result = client.GetUIDAsync().Result;

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success)
                {
                    AppLogger.Info($"Get UID: {result.data}");
                }
                else
                {
                    AppLogger.Error($"Get UID error, code: {result.code}, message: {result.message}");
                }
            }
        }

        private static void CreateSubUser()
        {
            var client = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);
            var user1 = new UserList
            {
                userName = "test",
                note = "note"
            };

            var request = new CreateSubUserRequest();
            request.userList = new UserList[1];
            request.userList[0] = user1;

            var result = client.CreateSubUserAsync(request).Result;

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Create {result.data.Length} sub users");
                    foreach (var creation in result.data)
                    {
                        AppLogger.Info($"Create sub user success, uid: {creation.uid}, userName: {creation.userName}");
                    }
                }
                else
                {
                    AppLogger.Error($"Create sub user error: {result.message}");
                }
            }
        }

        private static void LockSubUser()
        {
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.LockSubUserAsync(Config.SubUserId).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Lock sub user {result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    AppLogger.Info($"Lock sub user error: {result.code}");
                }
            }
        }

        private static void UnLockSubUser()
        {
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = accountClient.UnlockSubUserAsync(Config.SubUserId).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.code == (int)ResponseCode.Success && result.data != null)
                {
                    AppLogger.Info($"Unlock sub user {result.data.subUid} result: {result.data.userState}");
                }
                else
                {
                    AppLogger.Info($"Unlock sub user error: {result.code}");
                }
            }
        }

        private static void TransferCurrencyFromMasterToSub()
        {
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

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
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

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
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

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
            var accountClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

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

        private static void GetSubUserDepositAddress()
        {
            var walletClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var result = walletClient.GetSubUserDepositAddressAsync(Config.SubUserId, "btc").Result;
            _logger.StopAndLog();

            if (result != null)
            {
                if (result.data != null)
                {
                    AppLogger.Info($"Get sub user deposit address, id={result.data.Length}");
                    foreach (var a in result.data)
                    {
                        AppLogger.Info($"currency: {a.currency}, addr: {a.address}, chain: {a.chain}");
                    }
                }
                else
                {
                    AppLogger.Error($"Get sub user deposit address error: code={result.code}, message={result.message}");
                }
            }
        }

        private static void GetSubUserDepositHistory()
        {
            var walletClient = new SubUserClient(Config.AccessKey, Config.SecretKey,Config.Sign);

            _logger.Start();
            var request = new GetRequest()
                    .AddParam("subUid", Config.SubUserId);

            var result = walletClient.GetSubUserDepositHistoryAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                AppLogger.Info($"Get sub user deposit history, count={result.data.Length}");
                foreach (var h in result.data)
                {
                    AppLogger.Info($"Deposit history, id={h.id}, currency={h.currency}, amount={h.amount}, address={h.address}, updatedAt={h.updateTime}");
                }
            }
        }
    }
}
