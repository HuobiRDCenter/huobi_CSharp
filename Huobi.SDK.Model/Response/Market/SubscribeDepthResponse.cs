using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeDepth response
    /// </summary>
    public class SubscribeDepthResponse : WebSocketResponseBase
    {
        /// <summary>
        /// Response body from req
        /// </summary>
        public Tick data;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        public class Tick
        {
            /// <summary>
            /// Timestamp in millionsecond
            /// </summary>
            public long ts;

            /// <summary>
            /// Internal data
            /// </summary>
            public long version;

            /// <summary>
            /// The current all bids in format [price, quote volume]
            /// </summary>
            public float[][] bids;

            /// <summary>
            /// The current all asks in format [price, quote volume]
            /// </summary>
            public float[][] asks;
        }
    }
}
