using HuobiSDK.Model.Response.WebSocket;

namespace HuobiSDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeBestBidOffer response
    /// </summary>
    public class SubscribeBestBidOfferResponse : WebSocketResponseBase
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
            public long quoteTime;

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
