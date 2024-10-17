using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.ETF
{
    /// <summary>
    /// SwapIn and SwapOut response
    /// </summary>
    public class SwapETFResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Whether the response success or not
        /// </summary>
        public bool success;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message;

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object data;
    }
}
