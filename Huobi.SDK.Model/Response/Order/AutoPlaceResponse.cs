using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    public class AutoPlaceResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public AutoPlace Data;
        
        public class AutoPlace
        {
            [JsonProperty("order-id", NullValueHandling = NullValueHandling.Ignore)]
            public long OrderId;
        }
    }
}