namespace Huobi.SDK.Model.Response.WebSocket
{
    /// <summary>
    /// WebSocket Authentcation v2
    /// </summary>
    public class WebSocketAuthenticationV2Response
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
        /// Respons body
        /// </summary>
        public object data;
    }
}
