using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// GetMatchResults response
    /// </summary>
    public class GetMatchResultsResponse
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
        public MatchResult[] data;

        /// <summary>
        /// Match result of an order
        /// </summary>
        public class MatchResult
        {
            /// <summary>
            /// Internal id
            /// </summary>
            public long id;

            /// <summary>
            /// Order id of this order
            /// </summary>
            [JsonProperty("order-id")]
            public long orderId;

            /// <summary>
            /// Match id of this match
            /// </summary>
            [JsonProperty("match-id")]
            public long matchId;

            /// <summary>
            /// Unique trade id (NEW)
            /// </summary>
            [JsonProperty("trade-id")]
            public long tradeId;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// The limit price of limit order
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string price;

            /// <summary>
            /// The timestamp in milliseconds when the match and fill is done
            /// </summary>
            [JsonProperty("created-at")]
            public long createdAt;

            /// <summary>
            /// The order type
            /// Possible values: [buy-market, sell-market, buy-limit, sell-limit,
            ///         buy-ioc, sell-ioc, buy-limit-maker, sell-limit-maker,
            ///         buy-stop-limit, sell-stop-limit, buy-limit-fok, sell-limit-fok,
            ///         buy-stop-limit-fok, sell-stop-limit-fok]
            /// </summary>
            public string type;

            /// <summary>
            /// The amount which has been filled
            /// </summary>
            [JsonProperty("filled-amount")]
            public string filledAmount;
            
            /// <summary>
            /// Transaction fee paid so far
            /// </summary>
            [JsonProperty("filled-fees")]
            public string filledFees;

            /// <summary>
            /// Currency of transaction fee or transaction fee rebate
            /// </summary>
            [JsonProperty("fee-currency")]
            public string feeCurrency;

            /// <summary>
            /// The source where the order was triggered
            /// Possible values: [sys, web, api, app]
            /// </summary>
            public string source;

            /// <summary>
            /// The role in the transaction
            /// Possible values: [taker, maker]
            /// </summary>
            public string role;

            /// <summary>
            /// Deduction amount (unit: in ht or hbpoint)
            /// </summary>
            [JsonProperty("filled-points")]
            public string filledPoints;

            /// <summary>
            /// Deduction type. if blank, the transaction fee is based on original currency; if showing value as "ht", the transaction fee is deducted by HT; if showing value as "hbpoint", the transaction fee is deducted by HB point.
            /// </summary>
            [JsonProperty("fee-deduct-currency")]
            public string feeDeductCurrency;
        }
    }
}
