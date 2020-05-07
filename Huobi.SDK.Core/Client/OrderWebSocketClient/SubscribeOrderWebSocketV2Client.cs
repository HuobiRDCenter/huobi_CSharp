using Huobi.SDK.Core.Client.WebSocketClientBase;
using Huobi.SDK.Log;
using Huobi.SDK.Model.Response.Order;

namespace Huobi.SDK.Core.Client
{
    /// <summary>
    /// Responsible to handle order update from WebSocket
    /// This need authentication version 2
    /// </summary>
    public class SubscribeOrderWebSocketV2Client : WebSocketV2ClientBase<SubscribeOrderV2Response>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public SubscribeOrderWebSocketV2Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            :base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Subscribe order update for these events: creation, trade, cancellation.
        /// </summary>
        /// <param name="symbol">Trading symbol (wildcard * is allowed)</param>
        /// <param name="clientId"></param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"orders#{symbol}";

            _WebSocket.Send($"{{\"action\":\"sub\", \"ch\":\"{topic}\", \"cid\": \"{clientId}\" }}");

            AppLogger.Info($"WebSocket subscribed, topic={topic}");
        }

        /// <summary>
        /// Unsubscribe order update
        /// </summary>
        /// <param name="symbol">Trading symbol (wildcard * is allowed)</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"orders#{symbol}";

            _WebSocket.Send($"{{\"action\":\"unsub\", \"ch\":\"{topic}\", \"cid\": \"{clientId}\" }}");

            AppLogger.Info($"WebSocket unsubscribed, topic={topic}");
        }
    }
}
