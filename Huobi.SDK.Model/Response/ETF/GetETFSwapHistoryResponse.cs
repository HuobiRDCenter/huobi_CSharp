using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.ETF
{
    /// <summary>
    /// GetETFSwapHistory response
    /// </summary>
    public class GetETFSwapHistoryResponse
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
        public History[] data;

        /// <summary>
        /// Swap history
        /// </summary>
        public class History
        {
            /// <summary>
            /// Creation/Redemption id
            /// </summary>
            public long id;

            /// <summary>
            /// Operation timestamp
            /// </summary>
            [JsonProperty("gmt_created")]
            public long gmtCreated;

            /// <summary>
            /// ETF name
            /// </summary>
            public string currency;

            /// <summary>
            /// Creation/Redmption amount
            /// </summary>
            public double amount;

            /// <summary>
            /// Operation type
            /// Possible values: [Creation(1), Redemption(2)]
            /// </summary>
            public int type;

            /// <summary>
            /// Operation result
            /// </summary>
            public int status;

            /// <summary>
            /// Detail list
            /// </summary>
            public Detail[] detail;

            /// <summary>
            /// Detail
            /// </summary>
            public class Detail
            {
                /// <summary>
                /// UsedCurrency list
                /// </summary>
                [JsonProperty("used_currency_list")]
                public UsedCurrency[] usedCurrencyList;

                /// <summary>
                /// For creation this is the list and amount of underlying assets used for ETF creation.
                /// For redemption this is the amount of ETF used for redemption.
                /// </summary>
                public class UsedCurrency
                {
                    /// <summary>
                    /// Currency name
                    /// </summary>
                    public string currency;

                    /// <summary>
                    /// Amount
                    /// </summary>
                    public double amount;
                }

                /// <summary>
                /// Fee rate
                /// </summary>
                public double rate;

                /// <summary>
                /// The actual fee amount
                /// </summary>
                public double fee;

                /// <summary>
                /// Discount from point card
                /// </summary>
                [JsonProperty("point-card-amount")]
                public double pointCardAmount;

                /// <summary>
                /// ObtainCurrency list
                /// </summary>
                [JsonProperty("obtain_currency_list")]
                public ObtainCurrency[] obtainCurrencyList;

                /// <summary>
                /// For creation this is the amount for ETF created.
                /// For redemption this is the list and amount of underlying assets obtained.
                /// </summary>
                public class ObtainCurrency
                {
                    /// <summary>
                    /// Currency name
                    /// </summary>
                    public string currency;

                    /// <summary>
                    /// Amount
                    /// </summary>
                    public double amount;
                }
            }
        }
    }
}
