using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.WebSocket
{
    /// <summary>
    /// WebSocket Authentcation v1
    /// </summary>
    public class WebSocketAuthenticationV1Response
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
        /// Response body
        /// </summary>
        public Data data;

        public class Data
        {
            /// <summary>
            /// User id
            /// </summary>
            [JsonProperty("user-id")]
            public string userId;
        }
    }
}
