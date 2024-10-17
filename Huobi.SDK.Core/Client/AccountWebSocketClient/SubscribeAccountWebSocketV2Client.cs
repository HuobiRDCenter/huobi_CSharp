using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Core.Log;
using Huobi.SDK.Model.Response.Account;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle account asset subscription from WebSocket
    /// This need authentication version 2
    /// </summary>
    public class SubscribeAccountWebSocketV2Client : WebSocketV2ClientBase<SubscribeAccountV2Response>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public SubscribeAccountWebSocketV2Client(string accessKey, string secretKey,string sign, string host = DEFAULT_HOST)
            :base(accessKey, secretKey,sign, host)
        {
        }

        /// <summary>
        /// Subscribe all balance updates of the current account
        /// </summary>
        /// <param name="mode">Trigger mode
        /// 0: Only update when account balance changed
        /// 1: Update when either account balance changed or available balance changed</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string mode, string clientId = "")
        {
            string topic = $"accounts.update#{mode}";

            _WebSocket.Send($"{{\"action\":\"sub\", \"cid\": \"{clientId}\", \"ch\":\"{topic}\"}}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}");
        }

        /// <summary>
        /// Unsubscribe balance updates
        /// </summary>
        /// <param name="mode">Trigger mode</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string mode, string clientId = "")
        {
            string topic = $"accounts.update#{mode}";

            _WebSocket.Send($"{{\"action\":\"unsub\", \"cid\": \"{clientId}\", \"ch\":\"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}");
        }
    }
}
