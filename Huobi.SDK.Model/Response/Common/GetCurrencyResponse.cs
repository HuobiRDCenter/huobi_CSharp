namespace Huobi.SDK.Model.Response.Common
{
    /// <summary>
    /// GetCurrency response
    /// </summary>
    public class GetCurrencyResponse
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
        public Currency[] data;

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
            /// Chain list
            /// </summary>
            public Chain[] chains;

            /// <summary>
            /// Instrument status
            /// </summary>
            public string instStatus;

            /// <summary>
            /// Chain info
            /// </summary>
            public class Chain
            {
                /// <summary>
                /// Chain name
                /// </summary>
                public string chain;

                /// <summary>
                /// Base chain name
                /// </summary>
                public string baseChain;

                /// <summary>
                /// Base chain protocol
                /// </summary>
                public string baseChainProtocol;

                /// <summary>
                /// Is dynamic fee type or not (only applicable to withdrawFeeType = fixed)
                /// </summary>
                public bool isDynamic;

                /// <summary>
                /// Number of confirmations required for deposit success (trading and withdrawal allowed once reached)
                /// </summary>
                public int numOfConfirmations;

                /// <summary>
                /// Number of confirmations required for quick success (trading allowed but withdrawal disallowed once reached)
                /// </summary>
                public int numOfFastConfirmations;

                /// <summary>
                /// Minimal deposit amount in each request
                /// </summary>
                public string minDepositAmt;

                /// <summary>
                /// Deposit status
                /// Possible values [allowed, prohibited]
                /// </summary>
                public string depositStatus;

                /// <summary>
                /// Minimal withdraw amount in each request
                /// </summary>
                public string minWithdrawAmt;

                /// <summary>
                /// Maximum withdraw amount in each request
                /// </summary>
                public string maxWithdrawAmt;

                /// <summary>
                /// Maximum withdraw amount in a day
                /// </summary>
                public string withdrawQuotaPerDay;

                /// <summary>
                /// Maximum withdraw amount in a year
                /// </summary>
                public string withdrawQuotaPerYear;

                /// <summary>
                /// Maximum withdraw amount in total
                /// </summary>
                public string withdrawQuotaTotal;

                /// <summary>
                /// Withdraw amount precision
                /// </summary>
                public int withdrawPrecision;

                /// <summary>
                /// Type of withdraw fee (only one type can be applied to each currency)
                /// Possible values: [fixed, circulated, ratio]
                /// </summary>
                public string withdrawFeeType;

                /// <summary>
                /// Withdraw fee in each request (only applicable to withdrawFeeType = fixed)
                /// </summary>
                public string transactFeeWithdraw;

                /// <summary>
                /// Minimal withdraw fee in each request (only applicable to withdrawFeeType = circulated)
                /// </summary>
                public string minTransactFeeWithdraw;

                /// <summary>
                /// Maximum withdraw fee in each request (only applicable to withdrawFeeType = circulated or ratio)
                /// </summary>
                public string maxTransactFeeWithdraw;

                /// <summary>
                /// Withdraw fee in each request (only applicable to withdrawFeeType = ratio)
                /// </summary>
                public string transactFeeRateWithdraw;

                /// <summary>
                /// Withdraw status
                /// Possible values: [allowed, prohibited]
                /// </summary>
                public string withdrawStatus;
            }

        }
    }
}
