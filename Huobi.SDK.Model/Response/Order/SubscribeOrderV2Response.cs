using Huobi.SDK.Model.Response.WebSocket;
using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// SubscribeOrder response
    /// </summary>
    public class SubscribeOrderV2Response : WebSocketV2ResponseBase
    {
        /// <summary>
        /// Response bod
        /// </summary>
        public Update data;

        public class Update
        {
            /// <summary>
            /// Event type
            /// Possible values: [trigger, deletion, creation, trade, cancellation]
            /// </summary>
            public string eventType;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Account Id
            /// </summary>
            public long accountId;

            /// <summary>
            /// Order id
            /// </summary>
            public long orderId;

            /// <summary>
            /// Client order id
            /// </summary>
            public string clientOrderId;

            /// <summary>
            /// Order side, buy or sell
            /// </summary>
            public string orderSide;

            /// <summary>
            /// Error code for triggering failure
            /// </summary>
            public int errCode;

            /// <summary>
            /// Error message for triggering failure
            /// </summary>
            public string errMessage;

            /// <summary>
            /// Order type
            /// Possible values for creation eventType: [buy-market, sell-market, buy-limit, sell-limit,
            /// buy-limit-maker, sell-limit-maker, buy-ioc, sell-ioc, buy-limit-fok, sell-limit-fok]
            /// </summary>
            public string type;

            /// <summary>
            /// Order status
            /// Possible values for creation eventType: submitted
            /// </summary>
            public string orderStatus;

            /// <summary>
            /// Order price
            /// </summary>
            public string orderPrice;

            /// <summary>
            /// Order size (inapplicable for market buy order)
            /// </summary>
            public string orderSize;

            /// <summary>
            /// Order value (only applicable for market buy order)
            /// </summary>
            public string orderValue;

            /// <summary>
            /// Order create time, unix time in millisecond
            /// </summary>
            public long orderCreateTime;

            /// <summary>
            /// Trade Id
            /// </summary>
            public long tradeId;

            /// <summary>
            /// Trade price
            /// </summary>
            public string tradePrice;

            /// <summary>
            /// Trade volume
            /// </summary>
            public string tradeVolume;

            /// <summary>
            /// Trade time, unix time in millisecond
            /// </summary>
            public long tradeTime;

            /// <summary>
            /// Aggressor or not, true for taker, false for maker
            /// </summary>
            public bool aggressor;

            /// <summary>
            /// Remaining amount
            /// </summary>
            public string remainAmt;

            /// <summary>
            /// Last activity time, available for cancellation eventType
            /// </summary>
            public long lastActTime;
        }
    }
}
