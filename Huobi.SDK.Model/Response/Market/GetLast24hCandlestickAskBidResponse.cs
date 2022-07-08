namespace HuobiSDK.Model.Response.Market
{
    /// <summary>
    /// GetCandlestick response
    /// </summary>
    public class GetLast24hCandlestickAskBidResponse
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
        public Tick tick;

        /// <summary>
        /// The tick data
        /// </summary>
        public class Tick
        {
            /// <summary>
            /// Unix timestamp in seconds
            /// </summary>
            public long id;

            /// <summary>
            /// The aggregated trading volume in USDT
            /// </summary>
            public float amount;

            /// <summary>
            /// The number of completed trades
            /// </summary>
            public int count;

            /// <summary>
            /// The opening price
            /// </summary>
            public float open;

            /// <summary>
            /// The closing price
            /// </summary>
            public float close;

            /// <summary>
            /// The low price
            /// </summary>
            public float low;

            /// <summary>
            /// The high price
            /// </summary>
            public float high;

            /// <summary>
            /// The trading volume in base currency
            /// </summary>
            public float vol;

            /// <summary>
            /// The internal data
            /// </summary>
            public long version;

            /// <summary>
            /// The current best ask in format [price, quote volume]
            /// </summary>
            public float[] ask;

            /// <summary>
            /// The current best bit in format [price, quote volume]
            /// </summary>
            public float[] bid;
        }
    }
}
