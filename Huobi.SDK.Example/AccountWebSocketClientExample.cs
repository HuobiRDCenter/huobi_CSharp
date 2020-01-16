using System;
using Huobi.SDK.Core.Client;
using Huobi.SDK.Model.Response.Account;
using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Example
{
    public class AccountWebSocketClientExample
    {
        public static void RunAll()
        {
            APIKey.LoadAPIKey();

            RequestAccount();

            SubscribeAccountV1();

            SubscribeAccountV2();
        }

        private static void RequestAccount()
        {
            // Initialize a new instance
            var client = new RequestAccountWebSocketClient(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
            {
                if (response.errCode == 0)
                {
                    // Request full data if authentication passed
                    client.Request();
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(RequestAccountResponse response)
            {
                if (response != null && response.data != null)
                {
                    foreach (var a in response.data)
                    {
                        Console.WriteLine($"account id: {a.id}, type: {a.type}, state: {a.state}");
                        if (a.list != null)
                        {
                            foreach (var b in a.list)
                            {
                                Console.WriteLine($"currency: {b.currency}, type: {b.type}, balance: {b.balance}");
                            }
                        }
                    }
                }
            }

            // Then connect to server and wait for the handler to handle the response
            client.Connect();

            Console.WriteLine("Press ENTER to quit...\n");
            Console.ReadLine();
            
            // Delete handler
            client.OnDataReceived -= Client_OnDataReceived;
        }

        private static void SubscribeAccountV1()
        {
            // Initialize a new instance
            var client = new SubscribeAccountWebSocketV1Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV1Response response)
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
                    Console.WriteLine($"Account update: {response.data.@event}");
                    if (response.data.list != null)
                    {
                        foreach (var b in response.data.list)
                        {
                            Console.WriteLine($"account id: {b.accountId}, currency: {b.currency}, type: {b.type}, balance: {b.balance}");
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
            var client = new SubscribeAccountWebSocketV2Client(APIKey.AccessKey, APIKey.SecretKey);

            // Add the auth receive handler
            client.OnAuthenticationReceived += Client_OnAuthReceived;
            void Client_OnAuthReceived(WebSocketAuthenticationV2Response response)
            {
                if (response.code == 200)
                {
                    // Subscribe the specific topic
                    client.Subscribe("1");
                }
            }

            // Add the data receive handler
            client.OnDataReceived += Client_OnDataReceived;
            void Client_OnDataReceived(SubscribeAccountV2Response response)
            {
                if (response != null && response.data != null)
                {
                    var b = response.data;
                    Console.WriteLine($"Account update, currency: {b.currency}, id: {b.accountId}, balance: {b.balance}");                    
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
