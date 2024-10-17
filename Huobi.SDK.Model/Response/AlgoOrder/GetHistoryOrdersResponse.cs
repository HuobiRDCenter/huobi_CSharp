namespace Huobi.SDK.Model.Response.AlgoOrder
{
    public class GetHistoryOrdersResponse
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

            public string orderId;

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

            public long orderCreateTime;

            public string orderStatus;

            public int errCode;

            public string errMessage;
        }

        public long nextId;
    }
}
