using Newtonsoft.Json;

namespace HuobiSDK.Model.Response.Order
{
    /// <summary>
    /// GetDepth response
    /// </summary>
    public class GetLastTradesResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// The data stream
        /// </summary>
        public string ch;

        /// <summary>
        /// The timestamp (millisecond) when API respond
        /// </summary>
        public long ts;

        /// <summary>
        /// The response body
        /// </summary>
        public Tick[] data;

        /// <summary>
        /// The tick data
        /// </summary>
        public class Tick
        {
            public long id;

            /// <summary>
            /// The UNIX timestamp in milliseconds adjusted to Singapore time
            /// </summary>
            public long ts;

            /// <summary>
            /// The trade data
            /// </summary>
            public Trade[] data;

            /// <summary>
            /// The trade data
            /// </summary>
            public class Trade
            {
                /// <summary>
                /// The unique trade id (NEW)
                /// </summary>
                [JsonProperty(PropertyName = "trade-id")]
                public long tradeId;

                /// <summary>
                /// The trading volume in base currency
                /// </summary>
                public float amount;

                /// <summary>
                /// The trading price in quote currency
                /// </summary>
                public float price;

                /// <summary>
                /// The UNIX timestamp in milliseconds adjusted to Singapore time
                /// </summary>
                public long ts;

                /// <summary>
                /// The direction of the taker trade.
                /// Possible values: [buy, sell]
                /// </summary>
                public string direction;
            }
        }
    }
}
