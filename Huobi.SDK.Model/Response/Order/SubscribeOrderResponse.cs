using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    /// <summary>
    /// SubscribeOrder response
    /// </summary>
    public class SubscribeOrderResponse
    {
        /// <summary>
        /// Operation
        /// </summary>
        public string op;

        /// <summary>
        /// Timestamp
        /// </summary>
        public long ts;

        /// <summary>
        /// Subscription topic
        /// </summary>
        public string topic;

        /// <summary>
        /// Update
        /// </summary>
        public Update data;

        public class Update
        {
            /// <summary>
            /// Match id.
            /// While order-state = submitted, canceled, partial-canceled,match-id refers to sequence number;
            /// While order-state = filled, partial-filled, match-id refers to last match ID.
            /// </summary>
            [JsonProperty("match-id")]
            public int matchId;

            /// <summary>
            /// Order id
            /// </summary>
            [JsonProperty("order-id")]
            public long orderId;

            /// <summary>
            /// Trading symbol
            /// </summary>
            public string symbol;

            /// <summary>
            /// Order states
            /// Possible values: submitted, partial-filled, filled, canceled, partial-canceled
            /// </summary>
            [JsonProperty("order-state")]
            public string orderState;

            /// <summary>
            /// Order role in the trade: taker or maker.
            /// While order-state = submitted, canceled, partialcanceled, a default value “taker” is given to this field;
            /// While order-state = filled, partial-filled, role can be either taker or maker.
            /// </summary>
            public string role;

            /// <summary>
            /// Last price.
            /// While order-state = submitted, price refers to order price;
            /// While order-state = canceled, partial-canceled, price is zero;
            /// While order-state = filled, partial-filled, price reflects the last execution price.
            /// </summary>
            public string price;

            /// <summary>
            /// Last execution quantity (in base currency)
            /// </summary>
            [JsonProperty("filled-amount")]
            public string filledAmount;

            /// <summary>
            /// Last execution value (in quote currency)
            /// </summary>
            [JsonProperty("filled-cash-amount")]
            public string filledCashAmount;

            /// <summary>
            /// Remaining order quantity.
            /// While order-state = submitted, unfilled-amount contains the original order size;
            /// While order-state = canceled OR partial-canceled, unfilled-amount contains the remaining order quantity;
            /// While order-state = filled,
            ///     if order-type = buymarket, unfilled-amount could possibly contain a minimal value;
            ///     if order-type != buy-market, unfilled-amount is zero;
            /// While order-state = partial-filled AND role = taker, unfilled-amount is the remaining order quantity;
            /// While order-state = partial-filled AND role = maker, unfilled-amount is remaining order quantity.
            /// </summary>
            [JsonProperty("unfilled-amount")]
            public string unfilledAmount;

            /// <summary>
            /// Client order id
            /// </summary>
            [JsonProperty("client-order-id")]
            public string clientOrderId;

            /// <summary>
            /// Order type
            /// Possible values: [buy-market, sell-market, buy-limit, sell-limit, buy-ioc, sell-ioc,
            /// buy-limit-maker, sell-limit-maker,buy-stop-limit,sell-stop-limit, buy-limit-fok, sell-limit-fok]
            ///
            /// Note that the order type 'buy-stop-limit-fok' and 'sell-stop-limit-fok' will be converted to
            /// 'buy-limit-fok' and 'sell-limit-fok'
            /// </summary>
            [JsonProperty("order-type")]
            public string orderType;
        }
    }
}
