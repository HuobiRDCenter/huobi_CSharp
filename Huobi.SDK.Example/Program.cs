﻿using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            AppLogger.Info("Example started");

            Config.LoadConfig();

            RullAllExamples();

            AppLogger.Info("Example stopped");
        }

        static void RullAllExamples()
        {
            RunAllRestExamples();

            RunAllWebSocketExamples();
        }

        static void RunPerformanceTest()
        {
            PerformanceLogger.GetInstance().Enable(true);

            RunAllRestExamples();
        }

        static void RunAllRestExamples()
        {
            CommonClientExample.RunAll();

            MarketClientExample.RunAll();

            AccountClientExample.RunAll();

            WalletClientExample.RunAll();

            SubUserClientExample.RunAll();

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
