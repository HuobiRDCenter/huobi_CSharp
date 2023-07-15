using Newtonsoft.Json;

namespace HuobiSDK.Model.Response.Account
{
    public class GetPointBalanceResponse
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
            /// Account ID
            /// </summary>
            public string accountId;

            /// <summary>
            /// Account status (working, lock, fl-sys, fl-mgt, fl-end, fl-negative)
            /// </summary>
            public string accountStatus;

            /// <summary>
            /// Account balance
            /// </summary>
            public string acctBalance;

            public GroupId[] groupIds;

            public class GroupId
            {
                /// <summary>
                /// Group ID
                /// </summary>
                public long groupId;

                /// <summary>
                /// Expiration date (unix time in millisecond)
                /// </summary>
                [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
                public long expiryDate;

                /// <summary>
                /// Remaining amount
                /// </summary>
                public string remainAmt;
            }
        }
    }
}
