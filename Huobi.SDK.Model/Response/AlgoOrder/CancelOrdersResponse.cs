namespace Huobi.SDK.Model.Response.AlgoOrder
{
    public class CancelOrdersResponse
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
            public string[] accepted;

            public string[] rejected;
        }
    }
}
