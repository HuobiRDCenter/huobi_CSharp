using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// GetHistoryOrders and GetLast48hOrders response
    /// </summary>
    public class GetHistoryOrdersResponse
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
        public HistoryOrder[] data;

        /// <summary>
        /// History order
        /// </summary>
        public class HistoryOrder
        {
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
            /// The account id
            /// </summary>
            [JsonProperty("account-id")]
            public int accountId;

            /// <summary>
            /// User id
            /// </summary>
            [JsonProperty("user-id")]
            public int userId;

            /// <summary>
            /// The amount of base currency in this order
            /// </summary>
            public string amount;

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
            /// The timestamp in milliseconds when the order was canceled, or 0 if not canceled
            /// </summary>
            [JsonProperty("canceled-at")]
            public long canceledAt;

            /// <summary>
            /// The timestamp in milliseconds when the order was finished, or 0 if not finished
            /// </summary>
            [JsonProperty("finished-at")]
            public long finishedAt;

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
            [JsonProperty("filled-amount")]
            public string filledAmount;

            /// <summary>
            /// The filled total in quote currency
            /// </summary>
            [JsonProperty("filled-cash-amount")]
            public string filledCashAmount;

            /// <summary>
            /// Transaction fee paid so far
            /// </summary>
            [JsonProperty("filled-fees")]
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

            /// <summary>
            /// Internal data
            /// </summary>
            public string exchange;

            /// <summary>
            /// Internal data
            /// </summary>
            public string batch;

            /// <summary>
            /// Trigger price of stop limit order
            /// </summary>
            [JsonProperty("stop-price")]
            public string stopPrice;

            /// <summary>
            /// Operation charactor of stop price
            /// Possible values: [gte, lte]
            /// </summary>
            /// <returns></returns>
            public string @operator;
        }
    }
}
