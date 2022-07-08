namespace HuobiSDK.Model.Response.AlgoOrder
{
    public class GetOpenOrdersResponse
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
            public int accountId;

            public string source;

            public string clientOrderId;

            public string symbol;

            public string orderPrice;

            public string orderSize;

            public string orderValue;

            public string orderSide;

            public string timeInForce;

            public string orderType;

            public string stopPrice;

            public string trailingRate;

            public long orderOrigTime;

            public long lastActTime;

            public string orderStatus;
        }

        public long nextId;
    }
}
