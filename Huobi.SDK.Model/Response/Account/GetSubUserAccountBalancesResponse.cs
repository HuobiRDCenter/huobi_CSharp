namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// GetSubUserAccountBalance response
    /// </summary>
    public class GetSubUserAccountBalancesResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        public Balance[] data;

        /// <summary>
        /// Account balance
        /// </summary>
        public class Balance
        {
            /// <summary>
            /// The currency of this balance
            /// </summary>
            public string currency;

            /// <summary>
            /// The account type
            /// Possible values: [spot, margin, point, super-margin]
            /// </summary>
            public string type;

            /// <summary>
            /// The total balance in the main currency unit including all balance and frozen banlance
            /// </summary>
            public string balance;

        }
    }
}
