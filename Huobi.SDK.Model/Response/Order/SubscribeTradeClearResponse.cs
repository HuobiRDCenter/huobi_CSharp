using Huobi.SDK.Model.Response.WebSocket;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// SubscribeTradeClear response
    /// </summary>
    public class SubscribeTradeClearResponse : WebSocketV2ResponseBase
    {
        /// <summary>
        /// Response bod
        /// </summary>
        public Trade data;

        public class Trade
        {
            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Order id
            /// </summary>
            public long orderId;

            /// <summary>
            /// Trade price
            /// </summary>
            public string tradePrice;

            /// <summary>
            /// Trade volume
            /// </summary>
            public string tradeVolume;

            /// <summary>
            /// Order side
            /// Possible values: [buy, sell]
            /// </summary>
            public string orderSide;

            /// <summary>
            /// Order type
            /// Possible values: [buy-market, sell-market,buy-limit,sell-limit, buy-ioc,sell-ioc,
            /// buy-limit-maker,sell-limit-maker,buy-stop-limit,sell-stop-limit, buy-limit-fok, sell-limit-fok,
            /// buy-stop-limit-fok, sell-stop-limit-fok]
            /// </summary>
            public string orderType;

            /// <summary>
            /// Aggressor or not
            /// </summary>
            public bool aggressor;

            /// <summary>
            /// Trade id
            /// </summary>
            public long tradeId;

            /// <summary>
            /// Trade timestamp in millisecond
            /// </summary>
            public long tradeTime;

            /// <summary>
            /// Transaction fee
            /// </summary>
            public string trasactFee;

            /// <summary>
            /// Transaction fee deduction
            /// </summary>
            public string feeDeduct;

            /// <summary>
            /// Transaction fee deduction type
            /// Possible values: [ht,point]
            /// </summary>
            public string feeDeductType;
        }
    }
}
