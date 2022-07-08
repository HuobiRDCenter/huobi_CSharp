namespace HuobiSDK.Model.Response.Account
{
    public class TransferPointResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;

        public Data data;

        public class Data
        {
            /// <summary>
            /// Transaction ID
            /// </summary>
            public string transactId;

            /// <summary>
            /// Transaction time (unix time in millisecond)
            /// </summary>
            public long transactTime;
        }
    }
}
