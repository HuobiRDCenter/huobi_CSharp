namespace Huobi.SDK.Model.Response.Wallet
{
    public class GetWithdrawQuotaResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Response body
        /// </summary>
        public Quota data;

        /// <summary>
        /// Quota
        /// </summary>
        public class Quota
        {
            /// <summary>
            /// Crypto currency
            /// </summary>
            public string currency;

            /// <summary>
            /// Chains
            /// </summary>
            public Chain[] chains;

            /// <summary>
            /// Chain info
            /// </summary>
            public class Chain
            {
                /// <summary>
                /// Blockchain name
                /// </summary>
                public string chain;

                /// <summary>
                /// Maximum withdraw amount in each request
                /// </summary>
                public string maxWithdrawAmt;

                /// <summary>
                /// Maximum withdraw amount in a day
                /// </summary>
                public string withdrawQuotaPerDay;

                /// <summary>
                /// Remaining withdraw quota in the day
                /// </summary>
                public string remainWithdrawQuotaPerDay;

                /// <summary>
                /// Maximum withdraw amount in a year
                /// </summary>
                public string withdrawQuotaPerYear;

                /// <summary>
                /// Remaining withdraw quota in the year
                /// </summary>
                public string remainWithdrawQuotaPerYear;

                /// <summary>
                /// Maximum withdraw amount in total
                /// </summary>
                public string withdrawQuotaTotal;

                /// <summary>
                /// Remaining withdraw quota in total
                /// </summary>
                public string remainWithdrawQuotaTotal;
            }
        }
    }
}
