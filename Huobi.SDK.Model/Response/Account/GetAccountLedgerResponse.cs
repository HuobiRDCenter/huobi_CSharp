using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// GetAccountHistory response
    /// </summary>
    public class GetAccountLedgerResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;

        /// <summary>
        /// Response body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Ledger[] data;

        /// <summary>
        /// First record ID in next page (only valid if exceeded page size)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public long nextId;

        /// <summary>
        /// Ledger
        /// </summary>
        public class Ledger
        {
            /// <summary>
            /// Account Id
            /// </summary>
            public long accountId;

            /// <summary>
            /// Cryptocurrency
            /// </summary>
            public string currency;

            /// <summary>
            /// Transaction amount (income positive, expenditure negative)
            /// </summary>
            public string transactAmt;

            /// <summary>
            /// Transaction type
            /// Possible values: [transfer]
            /// </summary>
            public string transactType;

            /// <summary>
            /// Transfer type
            /// </summary>
            public string transferType;

            /// <summary>
            /// Transaction ID
            /// </summary>
            public long transactId;

            /// <summary>
            /// Transaction time
            /// </summary>
            public long transactTime;

            /// <summary>
            /// Transferer’s account ID
            /// </summary>
            public long transferer;

            /// <summary>
            /// Transferee’s account ID
            /// </summary>
            public long transferee;
        }
    }
}
