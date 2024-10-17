using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Model.Response.Market
{
    public class SubscribeTickerResponse : WebSocketResponseBase
    {
        /// <summary>
        /// Response body from req
        /// </summary>
        public Tick data;

        /// <summary>
        /// Response body from sub
        /// </summary>
        public Tick tick;

        /// <summary>
        /// Ticker
        /// </summary>
        public class Tick
        {
            public float amount;

            public int count;

            public float open;

            public float close;

            public float low;

            public float high;

            public float vol;

            public float bid;

            public float bidSize;

            public float ask;

            public float askSize;

            public float lastPrice;

            public float lastSize;
        }
    }
}