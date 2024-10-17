using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Margin
{
    /// <summary>
    /// GetIsolatedLoanInfo response
    /// </summary>
    public class GetIsolatedLoanInfoResponse
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
        public LoanInfo[] data;

        /// <summary>
        /// Loan info
        /// </summary>
        public class LoanInfo
        {
            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Currency list
            /// </summary>
            public Currency[] currencies;

            /// <summary>
            /// Currency detail
            /// </summary>
            public class Currency
            {
                /// <summary>
                /// Currency name
                /// </summary>
                public string currency;

                /// <summary>
                /// Interest rate
                /// </summary>
                [JsonProperty("interest-rate")]
                public string interestRate;

                /// <summary>
                /// Minimal loanable amount
                /// </summary>
                [JsonProperty("min-loan-amt")]
                public string minLoadAmt;

                /// <summary>
                /// Maximum loanable amount
                /// </summary>
                [JsonProperty("max-loan-amt")]
                public string maxLoanAmt;

                /// <summary>
                /// Remaining loanable amount
                /// </summary>
                [JsonProperty("loanable-amt")]
                public string loanableAmt;

                /// <summary>
                /// Actual interest rate
                /// </summary>
                [JsonProperty("actual-rate")]
                public string ActualRate;
            }
        }
    }
}
