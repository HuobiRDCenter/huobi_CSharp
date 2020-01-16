namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// GetCandlestick response
    /// </summary>
    public class GetCandlestickResponse
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
        public Candlestick[] data;

        /// <summary>
        /// Candlestick detail
        /// </summary>
        public class Candlestick
        {
            /// <summary>
            /// Unix timestamp in seconds
            /// </summary>
            public int id;

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
        }
    }
}
