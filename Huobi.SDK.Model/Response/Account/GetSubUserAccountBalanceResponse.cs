namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// GetSubUserAccountBalance response
    /// </summary>
    public class GetSubUserAccountBalanceResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        public Account[] data;

        /// <summary>
        /// Sub account info
        /// </summary>
        public class Account
        {
            /// <summary>
            /// Unique account id
            /// </summary>
            public int id;

            /// <summary>
            /// The type of this account
            /// Possible values: [spot, margin, otc, point, super-margin]
            /// </summary>
            public string type;

            /// <summary>
            /// Account state
            /// Possible values: [working, lock]
            /// </summary>
            public string state;

            /// <summary>
            /// The balance details of each currency
            /// </summary>
            public Balance[] list;

            public class Balance
            {
                /// <summary>
                /// The currency of this balance
                /// </summary>
                public string currency;

                /// <summary>
                /// The balance type
                /// Possible values: [trade, frozen]
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
