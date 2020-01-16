using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// PlaceMultipleOrders response
    /// </summary>
    public class PlaceOrdersResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PlaceOrderResult[] data;

        /// <summary>
        /// place order result
        /// </summary>
        public class PlaceOrderResult
        {
            /// <summary>
            /// The order id
            /// </summary>
            public long orderId;

            /// <summary>
            /// The client order id (if any)
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string clientOrderId;

            /// <summary>
            /// Error code for rejected order
            /// </summary>
            [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
            public string errorCode;

            /// <summary>
            /// Error message for rejected order
            /// </summary>
            [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
            public string errorMessage;
        }

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
