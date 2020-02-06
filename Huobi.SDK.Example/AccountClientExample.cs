using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;

namespace Huobi.SDK.Example
{
    public class AccountClientExample
    {
        public static void RunAll()
        {
            Config.LoadConfig();

            GetAccountInfo();

            GetAccountBalance();

            GetAccountHistory();

            TransferFromSpotToFuture();

            TransferFromFutureToSpot();

            TransferCurrencyFromMasterToSub();

            GetSubuserAccountBalances();

            GetSubuserAccountBalance();
        }

        private static void GetAccountInfo()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var getAIResult = accountClient.GetAccountInfoAsync().Result;
            if (getAIResult != null && getAIResult.data != null)
            {
                foreach (var a in getAIResult.data)
                {
                    Console.WriteLine($"account id: {a.id}, type: {a.type}, state: {a.state}");
                }
            }
        }

        private static void GetAccountBalance()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var getABResult = accountClient.GetAccountBalanceAsync(Config.AccountId).Result;
            if (getABResult != null)
            {
                switch (getABResult.status)
                {
                    case "ok":
                        {
                            if (getABResult.data != null && getABResult.data.list != null)
                            {
                                int availableCount = 0;
                                foreach (var b in getABResult.data.list)
                                {
                                    if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                                    {
                                        availableCount++;
                                        Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                                    }
                                }
                                Console.WriteLine($"There are total {getABResult.data.list.Length} currencys and available {availableCount} currencys in this account");
                            }
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get fail, error code: {getABResult.errorCode}, error message: {getABResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetAccountHistory()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var reqParams = new RequestParammeters()
                .AddParam("account-id", Config.AccountId);
            var getAHResult = accountClient.GetAccountHistoryAsync(reqParams).Result;
            if (getAHResult != null)
            {
                switch (getAHResult.status)
                {
                    case "ok":
                        {
                            foreach (var h in getAHResult.data)
                            {
                                Console.WriteLine($"currency: {h.currency}, amount: {h.transactAmt}, type: {h.transactType}, time: {h.transactTime}");
                            }
                            Console.WriteLine($"There are total {getAHResult.data.Length} transactions");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Get fail, error code: {getAHResult.errorCode}, error message: {getAHResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferFromSpotToFuture()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var transferS2FResult = accountClient.TransferFromSpotToFutureAsync("ht", 1).Result; // need further test
            if (transferS2FResult != null)
            {
                switch (transferS2FResult.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, trade id: {transferS2FResult.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {transferS2FResult.errorCode}, error message: {transferS2FResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferFromFutureToSpot()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var transferF2SResult = accountClient.TransferFromFutureToSpotAsync("ht", 1).Result; // need further test
            if (transferF2SResult != null)
            {
                switch (transferF2SResult.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, trade id: {transferF2SResult.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {transferF2SResult.errorCode}, error message: {transferF2SResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void TransferCurrencyFromMasterToSub()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var transferCP2SResult = accountClient.TransferCurrencyFromMasterToSubAsync(1, "ht", 1).Result;
            if (transferCP2SResult != null)
            {
                switch (transferCP2SResult.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Transfer successfully, trade id: {transferCP2SResult.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Transfer fail, error code: {transferCP2SResult.errorCode}, error message: {transferCP2SResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetSubuserAccountBalances()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var getSUABsResult = accountClient.GetSubUserAccountBalancesAsync().Result;
            if (getSUABsResult != null && getSUABsResult.data != null)
            {
                int availableCount = 0;
                foreach (var b in getSUABsResult.data)
                {
                    if (Math.Abs(float.Parse(b.balance)) > 0.00001)
                    {
                        availableCount++;
                        Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                    }
                }
                Console.WriteLine($"There are total {getSUABsResult.data.Length} currencys and available {availableCount} currencys in this account");
            }
        }

        private static void GetSubuserAccountBalance()
        {
            var accountClient = new AccountClient(Config.AccessKey, Config.SecretKey);

            var getSUABResult = accountClient.GetSubUserAccountBalanceAsync(128654510).Result;
            if (getSUABResult != null && getSUABResult.data != null)
            {
                foreach (var a in getSUABResult.data)
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
                Console.WriteLine($"There are total {getSUABResult.data.Length} accounts");
            }
        }
    }
}
