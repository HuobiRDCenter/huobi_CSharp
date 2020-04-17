namespace Huobi.SDK.Model.Response.WebSocket
{
    /// <summary>
    /// WebSocket v2 response base
    /// </summary>
    public abstract class WebSocketV2ResponseBase
    {
        /// <summary>
        /// Action
        /// </summary>
        public string action;

        /// <summary>
        /// Response code
        /// </summary>
        public int code;

        /// <summary>
        /// Channel
        /// </summary>
        public string ch;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;
    }
}
