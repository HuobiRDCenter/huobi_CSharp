using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Order;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle order request from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class RequestOrderWebSocketV1Client : WebSocketV1ClientBase<RequestOrderResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public RequestOrderWebSocketV1Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            : base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Get order details by a given order ID.
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="clientId">Client id</param>
        public void Request(string orderId, string clientId = "")
        {
            _WebSocket.Send($"{{ \"op\":\"req\", \"cid\": \"{clientId}\", \"topic\":\"orders.detail\", \"order-id\":\"{orderId}\" }}");
        }
    }
}