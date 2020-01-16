using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeBestBidOffer response
    /// </summary>
    public class SubscribeBestBidOfferResponse : WebSocketResponse
    {
        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        public class Tick
        {
            /// <summary>
            /// Quote timestamp in millionsecond
            /// </summary>
            public long quteTime;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Best bid
            /// </summary>
            public float bid;

            /// <summary>
            /// Best bid size
            /// </summary>
            public float bidSize;

            /// <summary>
            /// Best ask
            /// </summary>
            public float ask;

            /// <summary>
            /// Best ask size
            /// </summary>
            public float askSize;
        }
    }
}
