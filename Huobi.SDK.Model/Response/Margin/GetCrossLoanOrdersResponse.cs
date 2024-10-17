using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Margin
{
    /// <summary>
    /// GetCrossLoanOrders response
    /// </summary>
    public class GetCrossLoanOrdersResponse
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
            public LoanOrder[] data;

        /// <summary>
        /// Loan info
        /// </summary>
        public class LoanOrder
        {
            /// <summary>
            /// Order id
            /// </summary>
            public long id;

            /// <summary>
            /// Account id
            /// </summary>
            [JsonProperty("account-id")]
            public long accountId;

            /// <summary>
            /// User id
            /// </summary>
            [JsonProperty("user-id")]
            public long userId;
            
            /// <summary>
            /// The currency in the loan
            /// </summary>
            public string currency;

            /// <summary>
            /// Point deduction amount
            /// </summary>
            [JsonProperty("filled-points")]
            public string FilledPoints;

            /// <summary>
            /// HT deduction amount
            /// </summary>
            [JsonProperty("filled-ht")]
            public string FilledHt;

            /// <summary>
            /// The timestamp in milliseconds when the order was created
            /// </summary>
            [JsonProperty("created-at")]
            public long createdAt;

            /// <summary>
            /// The timestamp in milliseconds when the last accure happened
            /// </summary>
            [JsonProperty("accrued-at")]
            public long accruedAt;

            /// <summary>
            /// The amount of the origin loan
            /// </summary>
            [JsonProperty("loan-amount")]
            public string loanAmount;

            /// <summary>
            /// The amount of the loan left
            /// </summary>
            [JsonProperty("loan-balance")]
            public string loanBalance;

            /// <summary>
            /// The loan interest rate
            /// </summary>
            [JsonProperty("interest-rate")]
            public string interestRate;

            /// <summary>
            /// The accumulated loan interest
            /// </summary>
            [JsonProperty("interest-amount")]
            public string interestAmount;

            /// <summary>
            /// The amount of loan interest left
            /// </summary>
            [JsonProperty("interest-balance")]
            public string interestBalance;

            /// <summary>
            /// Loan state
            /// Possible values: [created, accrual, cleared, invalid]
            /// </summary>
            [JsonProperty("state")]
            public string state;
        }
    }
}
