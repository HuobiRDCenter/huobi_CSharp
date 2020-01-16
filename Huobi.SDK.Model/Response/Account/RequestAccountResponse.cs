using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    /// <summary>
    /// RequestAccount response
    /// </summary>
    public class RequestAccountResponse
    {
        public long ts;

        public string op;

        public string topic;

        [JsonProperty("err-code")]
        public int errCode;

        public string cid;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public AccountBalance[] data;

        public class AccountBalance
        {

            /// <summary>
            /// Account id
            /// </summary>
            public int id;

            /// <summary>
            /// Account type
            /// </summary>
            public string type;

            /// <summary>
            /// Account staus
            /// </summary>
            public string state;

            /// <summary>
            /// The list of account balance
            /// </summary>
            public Balance[] list;

            /// <summary>
            /// Account balance
            /// </summary>
            public class Balance
            {

                /// <summary>
                /// sub-account currency
                /// </summary>
                public string currency;

                /// <summary>
                /// sub-account type
                /// Possible values: [including trade, loan, interest]
                /// </summary>
                public string type;

                /// <summary>
                /// sub-account balance
                /// </summary>
                public string balance;
            }
        }
    }
}
