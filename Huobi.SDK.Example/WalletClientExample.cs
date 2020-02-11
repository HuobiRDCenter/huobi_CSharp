using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Request;

namespace Huobi.SDK.Example
{
    public class WalletClientExample
    {
        public static void RunAll()
        {
            Config.LoadConfig();

            GetDepoistAddress();

            GetWithdrawQuota();

            WithdrawCurrency();

            CancelWithdrawCurrency();

            GetDepositWithdrawHistory();
        }

        private static void GetDepoistAddress()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("currency", "btc");

            var getDAResult = walletClient.GetDepositAddressAsync(request).Result;
            if (getDAResult != null && getDAResult.data != null)
            {
                foreach (var a in getDAResult.data)
                {
                    Console.WriteLine($"currency: {a.currency}, addr: {a.address}, chain: {a.chain}");
                }
                Console.WriteLine($"There are total {getDAResult.data.Length} addresses");
            }
        }

        private static void GetWithdrawQuota()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                .AddParam("currency", "btc");

            var getWQResult = walletClient.GetWithdrawQuotaAsync(request).Result;
            if (getWQResult != null && getWQResult.data != null && getWQResult.data.chains != null)
            {
                foreach (var c in getWQResult.data.chains)
                {
                    Console.WriteLine($"chain: {c.chain}, max withdraw amount {c.maxWithdrawAmt}, total quota {c.withdrawQuotaTotal}");
                }
            }
        }

        private static void WithdrawCurrency()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            var request = new WithdrawRequest
            {
                address = ""
            };
            var withdrawCResult = walletClient.WithdrawCurrencyAsync(request).Result;
            if (withdrawCResult != null)
            {
                switch (withdrawCResult.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Withdraw successfully, transfer id: {withdrawCResult.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Withdraw fail, error code: {withdrawCResult.errorCode}, error message: {withdrawCResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void CancelWithdrawCurrency()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            var cancelWCResult = walletClient.CancelWithdrawCurrencyAsync(1).Result;
            if (cancelWCResult != null)
            {
                switch (cancelWCResult.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Cancel withdraw successfully, transfer id: {cancelWCResult.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Cancel withdraw fail, error code: {cancelWCResult.errorCode}, error message: {cancelWCResult.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetDepositWithdrawHistory()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            var request = new GetRequest()
                    .AddParam("type", "deposit");
            var getDWHResult = walletClient.GetDepositWithdrawHistoryAsync(request).Result;
            if (getDWHResult != null && getDWHResult.data != null)
            {
                foreach (var h in getDWHResult.data)
                {
                    Console.WriteLine($"type: {h.type}, currency: {h.currency}, amount: {h.amount}, updatedAt: {h.updatedAt}");
                }

                Console.WriteLine($"There are {getDWHResult.data.Length} deposit and withdraw history");
            }
        }
    }
}
