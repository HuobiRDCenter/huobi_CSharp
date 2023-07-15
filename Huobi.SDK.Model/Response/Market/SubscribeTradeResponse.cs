using HuobiSDK.Model.Response.WebSocket;

namespace HuobiSDK.Model.Response.Market
{
    /// <summary>
    /// SubscribeTrade response
    /// </summary>
    public class SubscribeTradeResponse : WebSocketResponseBase
    {
        /// <summary>
        /// Response body from req
        /// </summary>
        public Trade[] data;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        public class Tick
        {
            public long id;

            public string ts;

            public Trade[] data;
        }

        public class Trade
        {
            /// <summary>
            /// Unique trade id (NEW)
            /// </summary>
            public long tradeid;

            /// <summary>
            /// Last trade volume
            /// </summary>
            public float amount;

            /// <summary>
            /// Last trade price
            /// </summary>
            public float price;

            /// <summary>
            /// Last trade timestamp in millisecond)
            /// </summary>
            public long ts;

            /// <summary>
            /// Aggressive order side (taker's order side) of the trade
            /// Possible values: [buy, sell]
            /// </summary>
            public string direction;
        }
    }
}
