using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.WebSocket
{
    /// <summary>
    /// WebSocket v1 response base
    /// </summary>
    public abstract class WebSocketV1ResponseBase
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public long ts;

        /// <summary>
        /// Operation
        /// </summary>
        public string op;

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("err-code")]
        public int errCode;

        /// <summary>
        /// Topic
        /// </summary>
        public string topic;

        /// <summary>
        /// Client id
        /// </summary>
        public string cid;

    }
}
