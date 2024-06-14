using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Margin
{
    public class GetSubMarginLimitResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public MarginLimit[] Data;
        
        public class MarginLimit
        {
            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            public string Currency;

            [JsonProperty("maxHoldings", NullValueHandling = NullValueHandling.Ignore)]
            public string MaxHoldings;
        }
    }
}