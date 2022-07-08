using HuobiSDK.Model.Response.WebSocket;

namespace HuobiSDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeMarketByPrice response
    /// </summary>
    public class SubscribeMarketByPriceResponse : WebSocketResponseBase
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
            /// Sequence number of the message
            /// </summary>
            public long seqNum;

            /// <summary>
            /// Sequence number of previous message
            /// </summary>
            public long prevSeqNum;

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
