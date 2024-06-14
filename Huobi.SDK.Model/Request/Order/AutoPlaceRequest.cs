using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request.Order
{
    public class AutoPlaceRequest
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol;

        [JsonProperty("account-id", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountId;

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public string Amount;

        [JsonProperty("market-amount", NullValueHandling = NullValueHandling.Ignore)]
        public string MarketAmount;

        [JsonProperty("borrow-amount", NullValueHandling = NullValueHandling.Ignore)]
        public string BorrowAmount;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type;

        [JsonProperty("trade-purpose", NullValueHandling = NullValueHandling.Ignore)]
        public string TradePurpose;

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price;

        [JsonProperty("stop-price", NullValueHandling = NullValueHandling.Ignore)]
        public string StopPrice;

        [JsonProperty("operator", NullValueHandling = NullValueHandling.Ignore)]
        public string Operator;

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source;
        
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}