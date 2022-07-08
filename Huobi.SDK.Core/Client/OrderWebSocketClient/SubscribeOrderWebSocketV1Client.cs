using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Order;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle order subscription from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class SubscribeOrderWebSocketV1Client : WebSocketV1ClientBase<SubscribeOrderV1Response>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public SubscribeOrderWebSocketV1Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            : base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Subscribe all order updates of the current account
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"orders.{symbol}.update";

            _WebSocket.Send($"{{ \"op\":\"sub\", \"cid\": \"{clientId}\", \"topic\":\"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe order updates
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"orders.{symbol}.update";

            _WebSocket.Send($"{{ \"op\":\"unsub\", \"cid\": \"{clientId}\", \"topic\":\"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket unsubscribed, topic={topic}, clientId={clientId}");
        }
    }
}