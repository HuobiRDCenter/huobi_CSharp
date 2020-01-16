namespace Huobi.SDK.Model.Response.WebSocket
{
    public abstract class WebSocketResponse
    {
        /// <summary>
        /// Subscribe status
        /// </summary>
        public string status;

        /// <summary>
        /// Data stream
        /// </summary>
        public string ch;

        /// <summary>
        /// Respond timestamp in millisecond
        /// </summary>
        public long ts;
    }
}
