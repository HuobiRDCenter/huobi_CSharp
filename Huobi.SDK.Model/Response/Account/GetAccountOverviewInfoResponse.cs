using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Account
{
    public class GetAccountOverviewInfoResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public GetAccountOverviewInfo Data { get; set; }
        
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }
        
        public class GetAccountOverviewInfo
        {
            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            public string Currency { get; set; }
        }
    }
}