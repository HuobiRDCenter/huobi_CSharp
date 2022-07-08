namespace HuobiSDK.Model.Response.Order
{
    public class GetTransactFeeRateResponse
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
        public Fee[] data;

        public class Fee
        {
            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Basic fee rate - passive side
            /// </summary>
            public string makerFeeRate;

            /// <summary>
            /// Basic fee rate - aggressive side
            /// </summary>
            public string takerFeeRate;

            /// <summary>
            /// Deducted fee rate – passive side.
            /// If deduction is inapplicable or disabled, return basic fee rate
            /// </summary>
            public string actualMakerRate;

            /// <summary>
            /// Deducted fee rate – aggressive side.
            /// If deduction is inapplicable or disabled, return basic fee rate.
            /// </summary>
            public string actualTakerRate;
        }
    }
}
