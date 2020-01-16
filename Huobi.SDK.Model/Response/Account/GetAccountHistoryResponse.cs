using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// GetAccountHistory response
    /// </summary>
    public class GetAccountHistoryResponse
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
        public History[] data;

        /// <summary>
        /// Account history
        /// </summary>
        public class History
        {
            /// <summary>
            /// Account id
            /// </summary>
            [JsonProperty(PropertyName = "account-id")]
            public long accountId;

            /// <summary>
            /// Currency name
            /// </summary>
            public string currency;

            /// <summary>
            /// Amount change (positive value if income, negative value if outcome)
            /// </summary>
            [JsonProperty(PropertyName = "transact-amt")]
            public string transactAmt;

            /// <summary>
            /// Amount change types
            /// Possible values: [trade,etf, transact-fee, deduction, transfer, credit, liquidation,
            ///     interest, deposit-withdraw, withdraw-fee, exchange, other-types]
            /// </summary>
            [JsonProperty(PropertyName = "transact-type")]
            public string transactType;

            /// <summary>
            /// Available balance
            /// </summary>
            [JsonProperty(PropertyName = "avail-balance")]
            public string availableBalance;

            /// <summary>
            /// Account balance
            /// </summary>
            [JsonProperty(PropertyName = "acct-balance")]
            public string accountBalance;

            /// <summary>
            /// Transaction time (database time)
            /// </summary>
            [JsonProperty(PropertyName = "transact-time")]
            public long transactTime;

            /// <summary>
            /// Unique record ID in the database
            /// </summary>
            [JsonProperty(PropertyName = "record-id")]
            public string recordId;
        }
    }
}
