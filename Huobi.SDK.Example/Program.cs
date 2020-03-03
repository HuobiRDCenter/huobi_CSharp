using Huobi.SDK.Log;

namespace Huobi.SDK.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAll();
        }

        static void RunAll()
        {
            CommonClientExample.RunAll();

            MarketClientExample.RunAll();

            MarketWebSocketClientExample.RunAll();

            AccountClientExample.RunAll();

            AccountWebSocketClientExample.RunAll();

            WalletClientExample.RunAll();

            OrderClientExample.RunAll();

            OrderWebSocketClientExample.RunAll();

            IsolatedMarginClientExample.RunAll();

            CrossMarginClientExample.RunAll();

            StableCoinClientExample.RunAll();

            ETFClientExample.RunAll();
        }

        static void RestPerfTest()
        {
            PerformanceLogger.GetInstance().Enable(true);

            CommonClientExample.RunAll();

            MarketClientExample.RunAll();

            AccountClientExample.RunAll();

            WalletClientExample.RunAll();

            OrderClientExample.RunAll();

            IsolatedMarginClientExample.RunAll();

            CrossMarginClientExample.RunAll();

            StableCoinClientExample.RunAll();

            ETFClientExample.RunAll();
        }
    }
}
