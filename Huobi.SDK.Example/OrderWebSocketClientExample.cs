using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response.Order;
using Huobi.SDK.Model.Request;
using Huobi.SDK.Model.Response.WebSocket;
using Huobi.SDK.Model.Response;
using Huobi.SDK.Model.Response.Auth;

namespace Huobi.SDK.Example
{
    public class OrderWebSocketClientExample
    {
        public static void RunAll()
        {
            RequestOrder();

            RequestOrders();

            SubscribeOrder();

            SubscribeOrderV2();

            SubscribeTradeClear();
        }

        private static void RequestOrders()
        {
            // Initialize a new instance
            var client = new RequestOrdersWebSocketV1Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV1AuthResponse response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    var req = new RequestOrdersRequest
                    {
                        AccountId = Int32.Parse(Config.AccountId),
                        symbol = "btcusdt",
                        states = "submitted,created"
                    };
                    client.Request(req);
                    Console.WriteLine("Request sent");
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
            client.Connect(false);

            Console.WriteLine("Press ENTER to quit...\n");
            Console.ReadLine();

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void RequestOrder()
        {
            // Initialize a new instance
            var client = new RequestOrderWebSocketV1Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV1AuthResponse response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    client.Request("64318170222");
                    Console.WriteLine("Request sent");
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
            client.Connect(false);

            Console.WriteLine("Press ENTER to quit...\n");
            Console.ReadLine();

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void SubscribeOrder()
        {
            // Initialize a new instance
            var client = new SubscribeOrderWebSocketV1Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV1AuthResponse response)
            {
                if (response.errCode == 0)
                {
                    // Subscribe if authentication passed
                    client.Subscribe("btcusdt");
                    Console.WriteLine("Subscription sent");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeOrderV1Response response)
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

        private static void SubscribeOrderV2()
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
                    client.Subscribe("btcusdt");
                    Console.WriteLine("Subscription sent");
                }
                else
                {
                    Console.WriteLine($"Authentication fail, code: {response.code}, message: {response.message}");
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
                            Console.WriteLine($"Subscribe topic {response.ch} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Subscribe topic {response.ch} fail, error code: {response.code}, error message: {response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var o = response.data;
                        Console.WriteLine($"order update, event: {o.eventType}, symbol: {o.symbol}, type: {o.type}, status: {o.orderStatus}");
                    }
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
            var client = new SubscribeTradeClearWebSocketV2Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV2AuthResponse response)
            {
                if (response.code == (int)ResponseCode.Success)
                {
                    // Subscribe if authentication passed
                    client.Subscribe("btcusdt");
                    Console.WriteLine("Subscription sent");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeTradeClearResponse response)
            {
                if (response != null)
                {
                    if (response.action.Equals("sub"))
                    {
                        if (response.code == (int)ResponseCode.Success)
                        {
                            Console.WriteLine($"Subscribe topic {response.ch} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"Subscribe topic {response.ch} fail, error code: {response.code}, error message: {response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var t = response.data;
                        Console.WriteLine($"trade clear update, symbol: {t.symbol}, id: {t.orderId}, price: {t.tradePrice}, volume: {t.tradeVolume}");
                    }
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
