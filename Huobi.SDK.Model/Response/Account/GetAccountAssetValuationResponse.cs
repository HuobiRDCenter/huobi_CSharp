namespace Huobi.SDK.Model.Response.Account
{
    public class GetAccountAssetValuationResponse
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
        public Data data;

        public class Data
        {
            /// <summary>
            /// The valuation according to the certain fiat currency
            /// </summary>
            public string balance;

            /// <summary>
            /// Return time;
            /// </summary>
            public long timestamp;
        }
    }
}
