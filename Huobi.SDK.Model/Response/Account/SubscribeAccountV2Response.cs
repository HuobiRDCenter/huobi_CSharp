namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// SubscribeAccountV2 response
    /// </summary>
    public class SubscribeAccountV2Response
    {
        /// <summary>
        /// Action type
        /// </summary>
        public string action;

        /// <summary>
        /// Channel
        /// </summary>
        public string ch;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public AccountUpdate data;

        public class AccountUpdate
        {
            /// <summary>
            /// The crypto currency of this balance
            /// </summary>
            public string currency;

            /// <summary>
            /// The account id of this individual balance
            /// </summary>
            public int accountId;
            
            /// <summary>
            /// The balance of this account, include frozen balance if "model" was set to 1 in subscription
            /// </summary>
            public string balance;

            /// <summary>
            /// Change type
            /// Possible values: [order-place,order-match,order-refund,order-cancel,order-fee-refund,
            /// margin-transfer,margin-loan,margin-interest,margin-repay,other]
            /// </summary>
            public string changeType;

            /// <summary>
            /// Account type
            /// Possible values: [trade, frozen, loan, interest]
            /// </summary>
            public string accountType;

            /// <summary>
            /// Change timestamp in millisecond
            /// If it is null, then this message is account overview not update
            /// </summary>
            public long? changeTime;
        }
    }
}
