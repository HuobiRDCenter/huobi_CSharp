using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Account;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle account asset request from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class RequestAccountWebSocketV1ClientV : WebSocketV1ClientBase<RequestAccountResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public RequestAccountWebSocketV1ClientV(string accessKey, string secretKey, string host = DEFAULT_HOST)
            :base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Request all account data of the current user.
        /// </summary>
        /// <param name="clientId">Client id</param>
        public void Request(string clientId = "")
        {
            string topic = "accounts.list";

            _WebSocket.Send($"{{ \"op\":\"req\", \"cid\":\"{clientId}\", \"topic\": \"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={topic}");
        }
    }
}
