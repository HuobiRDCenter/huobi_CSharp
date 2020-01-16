using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response.Order;
using Huobi.SDK.Model.Request;
using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Example
{
    public class OrderWebSocketClientExample
    {
        public static void RunAll()
        {
            APIKey.LoadAPIKey();

            RequestOrder();

            RequestOrders();

            SubscribeOrder();

            SubscribeTradeClear();
        }

        private static void RequestOrders()
        {
            // Initialize a new instance
            var client = new RequestOrdersWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    var req = new RequestOrdersRequest
                    {
                        AccountId = Int32.Parse(APIKey.AccountId),
                        symbol = "btcusdt",
                        states = "submitted,created"
                    };
                    client.Request(req);
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestOrdersResponse response)
            {
                if (response != null && response.data != null)
                {
                    foreach (var o in response.data)
                    {
                        Console.WriteLine($"Order id {o.id}, symbol: {o.symbol}, price: {o.price}, state: {o.state}");
                    }
                    Console.WriteLine($"There are total {response.data.Length} orders");
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to quit...\n");
            Console.ReadLine();

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void RequestOrder()
        {
            // Initialize a new instance
            var client = new RequestOrderWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    client.Request("64318170222");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestOrderResponse response)
            {
                if (response != null && response.data != null)
                {
                    var o = response.data;
                    Console.WriteLine($"Order id {o.id}, symbol: {o.symbol}, price: {o.price}, filled amount: {o.filledAmount}");
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to quit...\n");
            Console.ReadLine();

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void SubscribeOrder()
        {
            // Initialize a new instance
            var client = new SubscribeOrderWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
            {
                if (response.errCode == 0)
                {
                    // Subscribe if authentication passed
                    client.Subscribe("btcusdt");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeOrderResponse response)
            {
                if (response != null && response.data != null)
                {
                    var o = response.data;
                    Console.WriteLine($"order update, symbol: {o.symbol}, id: {o.orderId}, role: {o.role}, filled amount: {o.filledAmount}");
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void SubscribeTradeClear()
        {
            // Initialize a new instance
            var client = new SubscribeTradeClearWebSocketV2Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV2Response response)
            {
                if (response.code == 200)
                {
                    // Subscribe if authentication passed
                    client.Subscribe("btcusdt");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeTradeClearResponse response)
            {
                if (response != null && response.data != null)
                {
                    var t = response.data;
                    Console.WriteLine($"trade clear update, symbol: {t.symbol}, id: {t.orderId}, price: {t.tradePrice}, volume: {t.tradeVolume}");
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("btcusdt");

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }
    }
}
