namespace HuobiSDK.Model.Response.Margin
{
    public class GetRepaymentResponse
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
        public Data[] data;

        public class Data
        {
            public string repayId;

            public long repayTime;

            public string accountId;

            public string currency;

            public string repaidAmount;

            public TransactId transactIds;

            public class TransactId
            {
                public long transactId;

                public string repaidPrincipal;

                public string repaidInterest;

                public string paidHT;

                public string paidPoint;
            }
        }

        public long nextId;
    }
}
