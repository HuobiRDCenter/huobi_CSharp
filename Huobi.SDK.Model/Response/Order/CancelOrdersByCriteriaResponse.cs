using Newtonsoft.Json;

namespace HuobiSDK.Model.Response.Order
{
    /// <summary>
    /// CancelOrdersByCriteria response
    /// </summary>
    public class CancelOrdersByCriteriaResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string errorCode;

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string errorMessage;

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Body data;

        /// <summary>
        /// Response body
        /// </summary>
        public class Body
        {
            /// <summary>
            /// The number of cancel request sent successfully
            /// </summary>
            [JsonProperty("success-count")]
            public int successCount;

            /// <summary>
            /// The number of cancel request failed
            /// </summary>
            [JsonProperty("failed-count")]
            public int failedCount;

            /// <summary>
            /// The next order id that can be cancelled
            /// </summary>
            [JsonProperty("next-id")]
            public int nextId;
        }
    }
}
