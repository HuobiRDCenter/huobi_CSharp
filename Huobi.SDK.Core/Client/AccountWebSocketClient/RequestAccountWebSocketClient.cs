using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Account;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle account asset from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class RequestAccountWebSocketClient : WebSocketV1ClientBase<RequestAccountResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public RequestAccountWebSocketClient(string accessKey, string secretKey, string host = DEFAULT_HOST)
            :base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Request all account data of the current user.
        /// </summary>
        /// <param name="clientId">Client id</param>
        public void Request(string clientId = "")
        {
            _WebSocket.Send($"{{ \"op\":\"req\", \"cid\":\"{clientId}\", \"topic\": \"accounts.list\" }}");
        }
    }
}
