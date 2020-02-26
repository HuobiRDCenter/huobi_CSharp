namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// GetLast24hCandlestick response
    /// </summary>
    public class GetLast24hCandlestickResponse
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
        /// Response body
        /// </summary>
        public Candlestick tick;

        /// <summary>
        /// Candlestick detail
        /// </summary>
        public class Candlestick
        {
            /// <summary>
            /// Unix timestamp in seconds
            /// </summary>
            public long id;

            /// <summary>
            /// The aggregated trading volume in USDT of last 24h
            /// </summary>
            public float amount;

            /// <summary>
            /// The number of completed trades of last 24h
            /// </summary>
            public int count;

            /// <summary>
            /// The opening price of last 24h
            /// </summary>
            public float open;

            /// <summary>
            /// The closing price of last 24h
            /// </summary>
            public float close;

            /// <summary>
            /// The low price of last 24h
            /// </summary>
            public float low;

            /// <summary>
            /// The high price of last 24h
            /// </summary>
            public float high;

            /// <summary>
            /// The trading volume in base currency of last 24h
            /// </summary>
            public float vol;

            public long version;
        }
    }
}
