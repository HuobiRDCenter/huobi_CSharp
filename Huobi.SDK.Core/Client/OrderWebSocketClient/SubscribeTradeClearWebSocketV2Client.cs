using HuobiSDK.Core.Client.WebSocketClientBase;
using HuobiSDK.Core.Log;
using HuobiSDK.Model.Response.Order;

namespace HuobiSDK.Core.Client
{
    /// <summary>
    /// Responsible to handle trade clear from WebSocket
    /// This need authentication version 2
    /// </summary>
    public class SubscribeTradeClearWebSocketV2Client : WebSocketV2ClientBase<SubscribeTradeClearResponse>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accessKey">API Access Key</param>
        /// <param name="secretKey">API Secret Key</param>
        /// <param name="host">API Host</param>
        public SubscribeTradeClearWebSocketV2Client(string accessKey, string secretKey, string host = DEFAULT_HOST)
            :base(accessKey, secretKey, host)
        {
        }

        /// <summary>
        /// Subscribe trade details including transaction fee and transaction fee deduction etc.
        /// It only updates when transaction occurs.
        /// </summary>
        /// <param name="symbol">Trading symbol (wildcard * is allowed)</param>
        /// <param name="clientId"></param>
        public void Subscribe(string symbol, string clientId = "")
        {
            string topic = $"trade.clearing#{symbol}";

            _WebSocket.Send($"{{\"action\":\"sub\", \"cid\": \"{clientId}\", \"ch\":\"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }

        /// <summary>
        /// Unsubscribe trade update
        /// </summary>
        /// <param name="symbol">Trading symbol (wildcard * is allowed)</param>
        /// <param name="clientId">Client id</param>
        public void UnSubscribe(string symbol, string clientId = "")
        {
            string topic = $"trade.clearing#{symbol}";

            _WebSocket.Send($"{{\"action\":\"unsub\", \"cid\": \"{clientId}\", \"ch\":\"{topic}\" }}");

            _logger.Log(LogLevel.Info, $"WebSocket subscribed, topic={topic}, clientId={clientId}");
        }
    }
}
