using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeCandlestick response
    /// </summary>
    public class SubscribeCandlestickResponse : WebSocketResponseBase
    {
        /// <summary>
        /// Response body from req
        /// </summary>
        public Tick[] data;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        /// <summary>
        /// Candlestick
        /// </summary>
        public class Tick
        {
            /// <summary>
            /// UNIX epoch timestamp in second as response id
            /// </summary>
            public long id;

            /// <summary>
            /// Aggregated trading volume during the interval (in base currency)
            /// </summary>
            public float amount;

            /// <summary>
            /// Number of trades during the interval
            /// </summary>
            public int count;

            /// <summary>
            /// Opening price during the interval
            /// </summary>
            public float open;

            /// <summary>
            /// Closing price during the interval
            /// </summary>
            public float close;

            /// <summary>
            /// Low price during the interval
            /// </summary>
            public float low;

            /// <summary>
            /// High price during the interval
            /// </summary>
            public float high;

            /// <summary>
            /// Aggregated trading value during the interval (in quote currency)
            /// </summary>
            public float vol;
        }
    }
}
