namespace Huobi.SDK.Model.Response.Wallet
{
    public class GetWithdrawAddressResponse
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
            /// Blockchain name
            /// </summary>
            public string chain;

            /// <summary>
            /// Deposit address
            /// </summary>
            public string address;

            /// <summary>
            /// Deposit address tag
            /// </summary>
            public string addressTag;

            /// <summary>
            /// The address note
            /// </summary>
            public string note;
        }
    }
}
