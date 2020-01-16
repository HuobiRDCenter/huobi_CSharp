using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Margin
{
    /// <summary>
    /// GetMarginAccount response
    /// </summary>
    public class GetMarginAccountResponse
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
        public Account[] data;

        /// <summary>
        /// Loan info
        /// </summary>
        public class Account
        {
            /// <summary>
            /// The margin loan pair
            /// </summary>
            public string symbol;

            /// <summary>
            /// Loan state
            /// Possible values: [created, accrual, cleared, invalid]
            /// </summary>
            public string state;

            /// <summary>
            /// The risk rate
            /// </summary>
            [JsonProperty("risk-rate")]
            public string riskRate;

            /// <summary>
            /// The price which triggers closeout
            /// </summary>
            [JsonProperty("fl-price")]
            public string flPrice;

            /// <summary>
            /// The list of margin accounts and their details
            /// </summary>
            public AccountDetail[] list;

            /// <summary>
            /// Currency detail
            /// </summary>
            public class AccountDetail
            {
                /// <summary>
                /// The currency of this balance
                /// </summary>
                public string currency;

                /// <summary>
                /// The balance type
                /// </summary>
                public string type;

                /// <summary>
                /// The balance in the main currency unit
                /// </summary>
                public string balance;
            }

        }
    }
}
