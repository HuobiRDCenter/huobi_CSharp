using Newtonsoft.Json;

namespace HuobiSDK.Model.Response.Common
{
    /// <summary>
    /// GetSymbols response
    /// </summary>
    public class GetSymbolsResponse
    {
        /// <summary>
        /// Response status
        /// </summary>
        public string status;

        /// <summary>
        /// Response body
        /// </summary>
        public Symbol[] data;

        /// <summary>
        /// Trading symbol
        /// </summary>
        public class Symbol
        {
            /// <summary>
            /// Base currency in a trading symbol
            /// </summary>
            [JsonProperty(PropertyName = "base-currency")]
            public string baseCurrency;

            /// <summary>
            /// Quote currency in a trading symbol
            /// </summary>
            [JsonProperty(PropertyName = "quote-currency")]
            public string quoteCurrency;

            /// <summary>
            /// Quote currency precision when quote price(decimal places)
            /// </summary>
            [JsonProperty(PropertyName = "price-precision")]
            public int pricePrecision;

            /// <summary>
            /// Base currency precision when quote amount(decimal places)
            /// </summary>
            [JsonProperty(PropertyName = "amount-precision")]
            public int amountPrecision;

            /// <summary>
            /// Trading section
            /// Possible values: [main，innovation]
            /// </summary>
            [JsonProperty(PropertyName = "symbol-partition")]
            public string symbolPartition;

            /// <summary>
            /// Trading symbol
            /// </summary>
            [JsonProperty(PropertyName = "symbol")]
            public string symbol;

            /// <summary>
            /// The status of the symbol；Allowable values: [online，offline,suspend].
            /// "online" - Listed, available for trading,
            /// "offline" - de-listed, not available for trading，
            /// "suspend"-suspended for trading
            /// </summary>
            [JsonProperty(PropertyName = "state")]
            public string state;

            /// <summary>
            /// Precision of value in quote currency (value = price * amount)
            /// </summary>
            [JsonProperty(PropertyName = "value-precision")]
            public int valuePrecision;

            /// <summary>
            /// Minimum order amount of limit order in base currency
            /// </summary>
            [JsonProperty("limit-order-min-order-amt")]
            public double limitOrderMinOrderAmt;

            /// <summary>
            /// Max order amount of limit order in base currency
            /// </summary>
            [JsonProperty("limit-order-max-order-amt")]
            public double limitOrderMaxOrderAmt;

            /// <summary>
            /// Minimum order amount of sell-market order in base currency 
            /// </summary>
            [JsonProperty("sell-market-min-order-amt")]
            public double sellMarketMinOrderAmt;

            /// <summary>
            /// Max order amount of sell-market order in base currency 
            /// </summary>
            [JsonProperty("sell-market-max-order-amt")]
            public double sellMarketMaxOrderAmt;

            /// <summary>
            /// Max order value of buy-market order in quote currency
            /// </summary>
            [JsonProperty("buy-market-max-order-value")]
            public double buyMarketMaxOrderValue;

            /// <summary>
            /// Minimum order value of limit order and buy-market order in quote currency
            /// </summary>
            [JsonProperty(PropertyName = "min-order-value")]
            public double minOrderValue;

            /// <summary>
            /// Max order value of limit order and buy-market order in USDT
            /// </summary>
            [JsonProperty(PropertyName = "max-order-value")]
            public double maxOrderValue;

            /// <summary>
            /// The applicable leverage ratio
            /// </summary>
            [JsonProperty(PropertyName = "leverage-ratio")]
            public double leverageRatio;

            /// <summary>
            /// Underlying ETP code (only valid for ETP symbols)
            /// </summary>
            public string underlying;

            /// <summary>
            /// Position charge rate (only valid for ETP symbols)
            /// </summary>
            [JsonProperty("mgmt-fee-rate")]
            public double mgmtFeeRate;

            /// <summary>
            /// Position charging time (in GMT+8, in format HH:MM:SS, only valid for ETP symbols)
            /// </summary>
            [JsonProperty("charge-time")]
            public string chargeTime;

            /// <summary>
            /// Regular position rebalance time (in GMT+8, in format HH:MM:SS, only valid for ETP symbols)
            /// </summary>
            [JsonProperty("rebal-time")]
            public string rebalTime;

            /// <summary>
            /// The threshold which triggers adhoc position rebalance (evaluated by actual leverage ratio, only valid for ETP symbols)
            /// </summary>
            [JsonProperty("rebal-threshold")]
            public double rebalThreshold;

            /// <summary>
            /// Initial NAV (only valid for ETP symbols)
            /// </summary>
            [JsonProperty("init-nav")]
            public double initNav;

            /// <summary>
            /// API trading enabled or not (possible value: enabled, disabled)
            /// </summary>
            [JsonProperty("api-trading")]
            public string apiTrading;
        }
    }
}
