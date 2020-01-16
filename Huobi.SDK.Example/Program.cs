namespace Huobi.SDK.Example
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
