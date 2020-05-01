 

namespace Huobi.SDK.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.LoadConfig();

            RullAllExamples();
        }

        static void RullAllExamples()
        {
            RunAllRestExamples();

            RunAllWebSocketExamples();
        }

        static void RunPerformanceTest()
        {
            RunAllRestExamples();
        }

        static void RunAllRestExamples()
        {
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

        static void RunAllWebSocketExamples()
        {
            MarketWebSocketClientExample.RunAll();

            AccountWebSocketClientExample.RunAll();

            OrderWebSocketClientExample.RunAll();

        }

    }
}
