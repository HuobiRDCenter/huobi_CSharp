using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response;
using Huobi.SDK.Model.Response.Account;
using Huobi.SDK.Model.Response.Auth;

namespace Huobi.SDK.Example
{
    public class AccountWebSocketClientExample
    {
        public static void RunAll()
        {
            RequestAccount();

            SubscribeAccountV1();

            SubscribeAccountV2();
        }

        private static void RequestAccount()
        {
            // Initialize a new instance
            var client = new RequestAccountWebSocketV1ClientV(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV1AuthResponse response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    client.Request();
                }
                else
                {
                    AppLogger.Error($"Authentication fail, errorCode={response.errCode}");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestAccountResponse response)
            {
                if (response != null && response.data != null)
                {
                    AppLogger.Info($"WebSocket returned data, topic={response.topic}, count={response.data.Length}");
                    foreach (var a in response.data)
                    {
                        if (a.list != null)
                        {
                            AppLogger.Info($"count={a.list.Length}, accountId={a.id}, type={a.type}, state={a.state}");
                            foreach (var b in a.list)
                            {
                                AppLogger.Info($"currency={b.currency}, type={b.type}, balance={b.balance}");
                            }
                        }
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

        private static void SubscribeAccountV1()
        {
            // Initialize a new instance
            var client = new SubscribeAccountWebSocketV1Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV1AuthResponse response)
            {
                if (response.errCode == 0)
                {
                    // Subscribe the specific topic
                    client.Subscribe("1");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeAccountV1Response response)
            {
                if (response != null && response.data != null)
                {
                    AppLogger.Info($"WebSocket received data, topic={response.topic}, event={response.data.@event}");
                    if (response.data.list != null)
                    {
                        AppLogger.Info($"count={response.data.list.Length}");
                        foreach (var b in response.data.list)
                        {
                            AppLogger.Info($"account id: {b.accountId}, currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                        }
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("1");

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void SubscribeAccountV2()
        {
            // Initialize a new instance
            var client = new SubscribeAccountWebSocketV2Client(Config.AccessKey, Config.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketV2AuthResponse response)
            {
                if (response.code == (int)ResponseCode.Success)
                {
                    // Subscribe the specific topic
                    client.Subscribe("1");
                }
                else
                {
                    AppLogger.Error($"WebSocket authentication fail, code={response.code}, message={response.message}");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeAccountV2Response response)
            {
                if (response != null)
                {
                    if (response.action.Equals("sub"))
                    {
                        if (response.code == (int)ResponseCode.Success)
                        {
                            AppLogger.Info($"WebSocket subscribed successfully, topic={response.ch} ");
                        }
                        else
                        {
                            AppLogger.Info($"WebSocket subscribed topic fail, topic={response.ch}, errorCode={response.code}, errorMessage={response.message}");
                        }
                    }
                    else if (response.action.Equals("push") && response.data != null)
                    {
                        var b = response.data;
                        if (b.changeTime == null)
                        {
                            AppLogger.Info($"WebSocket returned data, topic={response.ch}, currency={b.currency}, id={b.accountId}, balance={b.balance}, available={b.available}");
                        }
                        else
                        {
                            AppLogger.Info($"WebSocket received data, topic={response.ch}, currency={b.currency}, id={b.accountId}, balance={b.balance}, available={b.available}, time={b.changeTime}");
                        }
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to unsubscribe and stop...\n");
            Console.ReadLine();

            // Unsubscrive the specific topic
            client.UnSubscribe("1");

            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }
    }
}
