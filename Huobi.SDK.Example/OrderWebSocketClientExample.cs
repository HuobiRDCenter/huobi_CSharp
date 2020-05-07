using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response.Order;
using Huobi.SDK.Model.Request;
using Huobi.SDK.Model.Response;
using Huobi.SDK.Model.Response.Auth;
using Huobi.SDK.Log;

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
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestOrdersResponse response)
            {
                if (response != null && response.data != null)
                {
                    AppLogger.Info($"WebSocket returned data, topic={response.topic}, count={response.data.Length}");
                    foreach (var o in response.data)
                    {
                        AppLogger.Info($"Order id {o.id}, symbol: {o.symbol}, price: {o.price}, state: {o.state}");
                    }
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
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestOrderResponse response)
            {
                if (response != null && response.data != null)
                {
                    var o = response.data;
                    AppLogger.Info($"WebSocket received data, topic={response.topic}, orderId={o.id}, symbol={o.symbol}, price={o.price}, filledAmount={o.filledAmount}");
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
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeOrderV1Response response)
            {
                if (response != null && response.data != null)
                {
                    var o = response.data;
                    AppLogger.Info($"WebSocket received data, topic={response.topic}, symbol={o.symbol}, id={o.orderId}, role={o.role}, filledAmount={o.filledAmount}");
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
                }
                else
                {
                    AppLogger.Error($"WebSocket authentication fail, code={response.code}, message={response.message}");
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
                            AppLogger.Info($"WebSocket subscribe successfully, topic={response.ch} ");
                        }
                        else
                        {
                            AppLogger.Error($"WebSocket subscribed fail, topic={response.ch}, errorCode={response.code}, errorMessage={response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var o = response.data;
                        AppLogger.Info($"WebSocket received data, topic={response.ch}, event={o.eventType}, symbol={o.symbol}, type={o.type}, status={o.orderStatus}");
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
                }
                else
                {
                    AppLogger.Error($"WebSocket authentication fail, code={response.code}, message={response.message}");
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
                            AppLogger.Info($"WebSocket subscribe successfully, topic={response.ch}");
                        }
                        else
                        {
                            AppLogger.Error($"WebSocket subscribe fail, topic={response.ch}, errorCode={response.code}, errorMessage={response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var t = response.data;
                        AppLogger.Info($"WebSocket received data, topic={response.ch}, symbol={t.symbol}, id={t.orderId}, price={t.tradePrice}, volume={t.tradeVolume}");
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
