using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Account;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle account asset subscription from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class SubscribeAccountWebSocketV1Client : WebSocketV1ClientBase<SubscribeAccountV1Response>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public SubscribeAccountWebSocketV1Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            :base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Subscribe all balance updates of the current account
        /// </summary>
        /// <param name="model">Whether to include frozen balance.
        /// 1 to include frozen balance
        /// 0 to not</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string model, string clientId = "")
        {
            string topic = "accounts";

            _WebSocket.Send($"{{ \"op\":\"sub\", \"cid\": \"{clientId}\", \"topic\":\"{topic}\", \"model\": \"{model}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, model={model}");
        }

        /// <summary>
        /// Unsubscribe balance updates
        /// </summary>
        /// <param name="model">Whether to include frozen balance.</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string model, string clientId = "")
        {
            string topic = "accounts";

            _WebSocket.Send($"{{ \"op\":\"unsub\", \"cid\": \"{clientId}\", \"topic\":\"{topic}\", \"model\": \"{model}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, model={model}");
        }
    }
}
