namespace Huobi.SDK.Model.Response.Wallet
{
    /// <summary>
    /// GetDepositAddress response
    /// </summary>
    public class GetDepositAddressResponse
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
        public Address[] data;

        /// <summary>
        /// Deposit address
        /// </summary>
        public class Address
        {
            /// <summary>
            /// Crypto currency
            /// </summary>
            public string currency;

            /// <summary>
            /// Deposit address
            /// </summary>
            public string address;

            /// <summary>
            /// Deposit address tag
            /// </summary>
            public string addressTag;

            /// <summary>
            /// Blockchain name
            /// </summary>
            public string chain;

            public string note;
        }
    }
}
