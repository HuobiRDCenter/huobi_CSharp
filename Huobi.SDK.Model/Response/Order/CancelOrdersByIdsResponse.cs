using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// CancelOrdersByIds response
    /// </summary>
    public class CancelOrdersByIdsResponse
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
            /// Cancelled order list
            /// </summary>
            public string[] success;

            /// <summary>
            /// Failed order list
            /// </summary>
            public FailedOrder[] failed;

            public class FailedOrder
            {
                /// <summary>
                /// Order id
                /// </summary>
                [JsonProperty("order-id", NullValueHandling = NullValueHandling.Ignore)]
                public long orderId;

                /// <summary>
                /// Client order id
                /// </summary>
                [JsonProperty("client-order-id", NullValueHandling = NullValueHandling.Ignore)]
                public string clientOrderId;

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
            }
        }
    }
}
