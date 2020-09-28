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
            /// Event type
            /// </summary>
            public string eventType;

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
            /// Currency of transaction fee or transaction fee rebate
            /// </summary>
            public string feeCurrency;

            /// <summary>
            /// Transaction fee deduction
            /// </summary>
            public string feeDeduct;

            /// <summary>
            /// Transaction fee deduction type
            /// Possible values: [ht,point]
            /// </summary>
            public string feeDeductType;

            /// <summary>
            /// Account ID
            /// </summary>
            public long accountId;

            /// <summary>
            /// Order source
            /// </summary>
            public string source;

            /// <summary>
            /// Order price (invalid for market order)
            /// </summary>
            public string orderPrice;

            /// <summary>
            /// Order size (invalid for market buy order)
            /// </summary>
            public string orderSize;

            /// <summary>
            /// Order value (only valid for market buy order)
            /// </summary>
            public string orderValue;

            /// <summary>
            /// Client order ID
            /// </summary>
            public string clientOrderId;

            /// <summary>
            /// Stop price (only valid for stop limit order)
            /// </summary>
            public string stopPrice;

            /// <summary>
            /// Operation character (only valid for stop limit order)
            /// </summary>
            public string @operator;

            /// <summary>
            /// Order creation time
            /// </summary>
            public long orderCreateTime;

            /// <summary>
            /// Order status, valid value: filled, partial-filled
            /// </summary>
            public string orderStatus;

            /// <summary>
            /// Remaining order amount (if market buy order, it implicates remaining order value)
            /// </summary>
            public string remainAmt;
        }
    }
}
