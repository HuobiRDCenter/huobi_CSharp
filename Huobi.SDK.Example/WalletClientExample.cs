using System;
using Huobi.SDK.Core;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Log;
using Huobi.SDK.Model.Request;

namespace Huobi.SDK.Example
{
    public class WalletClientExample
    {
        private static PerformanceLogger _logger = PerformanceLogger.GetInstance();

        public static void RunAll()
        {
            GetDepoistAddress();

            GetWithdrawQuota();

            WithdrawCurrency();

            CancelWithdrawCurrency();

            GetDepositWithdrawHistory();
        }

        private static void GetDepoistAddress()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("currency", "btc");

            var result = walletClient.GetDepositAddressAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                foreach (var a in result.data)
                {
                    Console.WriteLine($"currency: {a.currency}, addr: {a.address}, chain: {a.chain}");
                }
                Console.WriteLine($"There are total {result.data.Length} addresses");
            }
        }

        private static void GetWithdrawQuota()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                .AddParam("currency", "btc");

            var result = walletClient.GetWithdrawQuotaAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null && result.data.chains != null)
            {
                foreach (var c in result.data.chains)
                {
                    Console.WriteLine($"chain: {c.chain}, max withdraw amount {c.maxWithdrawAmt}, total quota {c.withdrawQuotaTotal}");
                }
            }
        }

        private static void WithdrawCurrency()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new WithdrawRequest
            {
                address = ""
            };
            var result = walletClient.WithdrawCurrencyAsync(request).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Withdraw successfully, transfer id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Withdraw fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void CancelWithdrawCurrency()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var result = walletClient.CancelWithdrawCurrencyAsync(1).Result;
            _logger.StopAndLog();

            if (result != null)
            {
                switch (result.status)
                {
                    case "ok":
                        {
                            Console.WriteLine($"Cancel withdraw successfully, transfer id: {result.data}");
                            break;
                        }
                    case "error":
                        {
                            Console.WriteLine($"Cancel withdraw fail, error code: {result.errorCode}, error message: {result.errorMessage}");
                            break;
                        }
                }
            }
        }

        private static void GetDepositWithdrawHistory()
        {
            var walletClient = new WalletClient(Config.AccessKey, Config.SecretKey);

            _logger.Start();
            var request = new GetRequest()
                    .AddParam("type", "deposit");
            var result = walletClient.GetDepositWithdrawHistoryAsync(request).Result;
            _logger.StopAndLog();

            if (result != null && result.data != null)
            {
                foreach (var h in result.data)
                {
                    Console.WriteLine($"type: {h.type}, currency: {h.currency}, amount: {h.amount}, updatedAt: {h.updatedAt}");
                }

                Console.WriteLine($"There are {result.data.Length} deposit and withdraw history");
            }
        }
    }
}
