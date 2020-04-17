using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Order;

namespace Huobi.SDK.Core.Client
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
            _WebSocket.Send($"{{ \"op\":\"sub\", \"cid\": \"{clientId}\", \"topic\":\"orders.{symbol}.update\" }}");
        }

        /// <summary>
        /// Unsubscribe order updates
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            _WebSocket.Send($"{{ \"op\":\"unsub\", \"cid\": \"{clientId}\", \"topic\":\"orders.{symbol}.update\" }}");
        }
    }
}