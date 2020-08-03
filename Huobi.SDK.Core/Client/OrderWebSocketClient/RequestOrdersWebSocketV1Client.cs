using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Model.Response.Order;
using Huobi.SDK.Model.Request;
using Huobi.SDK.Core.Log;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle orders request from WebSocket
    /// This need authentication version 1
    /// </summary>
    public class RequestOrdersWebSocketV1Client : WebSocketV1ClientBase<RequestOrdersResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public RequestOrdersWebSocketV1Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            : base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Search past and open orders based on searching criteria.
        /// </summary>
        /// <param name="request">request</param>
        public void Request(RequestOrdersRequest request)
        {
            _WebSocket.Send(request.ToJson());

            _logger.Log(LogLevel.Info, $"WebSocket requested, topic={request.topic}, accountId={request.AccountId} symbol={request.symbol}");
        }
    }
}