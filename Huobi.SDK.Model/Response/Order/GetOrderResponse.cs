using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// The response for GetOrderById and GetOrderByClient
    /// </summary>
    public class GetOrderResponse
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
        public Order data;

        /// <summary>
        /// Order
        /// </summary>
        public class Order
        {
            /// <summary>
            /// The account id
            /// </summary>
            [JsonProperty("account-id")]
            public int accountId;

            /// <summary>
            /// The order size
            /// </summary>
            public string amount;

            /// <summary>
            /// Order id
            /// </summary>
            public long id;

            /// <summary>
            /// Client order id (if specified)
            /// </summary>
            [JsonProperty("client-order-id")]
            public string ClientOrderId;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// The limit price of limit order
            /// </summary>
            public string price;

            /// <summary>
            /// The timestamp in milliseconds when the order was created
            /// </summary>
            [JsonProperty("created-at")]
            public long createdAt;

            /// <summary>
            /// The order type
            /// Possible values: [buy-market, sell-market, buy-limit, sell-limit,
            ///         buy-ioc, sell-ioc, buy-limit-maker, sell-limit-maker,
            ///         buy-stop-limit, sell-stop-limit]
            /// </summary>
            public string type;

            /// <summary>
            /// The amount which has been filled
            /// </summary>
            [JsonProperty("field-amount")]
            public string filledAmount;

            /// <summary>
            /// The filled total in quote currency
            /// </summary>
            [JsonProperty("field-cash-amount")]
            public string filledCashAmount;

            /// <summary>
            /// Transaction fee paid so far
            /// </summary>
            [JsonProperty("field-fees")]
            public string filledFees;

            /// <summary>
            /// The source where the order was triggered
            /// Possible values: [sys, web, api, app]
            /// </summary>
            public string source;

            /// <summary>
            /// The orders state
            /// Possible values: [submitted, partial-filled, cancelling, created]
            /// </summary>
            public string state;
        }
    }
}
