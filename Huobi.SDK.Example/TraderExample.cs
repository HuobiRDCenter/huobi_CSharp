using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Request.Order;
using Huobi.SDK.Model.Response;
using Huobi.SDK.Model.Response.Auth;
using Huobi.SDK.Model.Response.Order;

namespace Huobi.SDK.Example
{
    public class TraderExample
    {
        public static void Run()
        {
            string symbol = "hthusd";

            var client = SubscribeOrderV2(symbol);

            Console.WriteLine("Press ENTER to place an order...\n");
            Console.ReadLine();

            PlaceAnOrder(symbol, "1", "10");

            Console.WriteLine("Press ENTER to unsubscribe and exit...\n");
            Console.ReadLine();

            UnsubscribeOrderV2(client, symbol);
        }


        private static SubscribeOrderWebSocketV2Client SubscribeOrderV2(string symbol)
        {
            // Initialize a new instance
            var client = new SubscribeOrderWebSocketV2Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV2AuthResponse response)
            {
                if (response.code == (int)ResponseCode.Success)
                {
                    // Subscribe if authentication passed
                    client.Subscribe(symbol);
                    AppLogger.Info($"Order update {symbol} subscription sent");
                }
                else
                {
                    AppLogger.Info($"Authentication fail, code: {response.code}, message: {response.message}");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeOrderV2Response response)
            {
                if (response != null)
                {
                    if (response.action.Equals("sub"))
                    {
                        if (response.code == (int)ResponseCode.Success)
                        {
                            AppLogger.Info($"Subscribe topic {response.ch} successfully");
                        }
                        else
                        {
                            AppLogger.Info($"Subscribe topic {response.ch} fail, error code: {response.code}, error message: {response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var o = response.data;
                        AppLogger.Info($"order update, event: {o.eventType}, symbol: {o.symbol}, type: {o.type}, status: {o.orderStatus}");
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            return client;
        }

        private static void UnsubscribeOrderV2(SubscribeOrderWebSocketV2Client client, string symbol)
        {
            // Unsubscrive the specific topic
            client.UnSubscribe(symbol);
        }

        private static void PlaceAnOrder(string symbol, string price, string amount)
        {
            var tradeClient = new OrderClient(Config.AccessKey, Config.SecretKey);

            var request = new PlaceOrderRequest
            {
                AccountId = Config.AccountId,
                type = "buy-limit",
                symbol = symbol,
                source = "spot-api",
                amount = amount,
                price = price
            };

            var response = tradeClient.PlaceOrderAsync(request).Result;

            switch (response.status)
            {
                case "ok":
                    {
                        AppLogger.Info($"Place order successfully, order id: {response.data}");
                        break;
                    }
                case "error":
                    {
                        AppLogger.Info($"Place order fail, error code: {response.errorCode}, error message: {response.errorMessage}");
                        break;
                    }
            }
        }
    }
}
