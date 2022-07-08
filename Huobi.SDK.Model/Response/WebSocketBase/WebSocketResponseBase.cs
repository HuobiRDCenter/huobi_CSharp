namespace HuobiSDK.Model.Response.WebSocket
{
    /// <summary>
    /// WebSocket response base
    /// </summary>
    public abstract class WebSocketResponseBase
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
