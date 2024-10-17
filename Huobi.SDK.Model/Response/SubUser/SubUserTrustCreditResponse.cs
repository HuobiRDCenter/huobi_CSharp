using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserTrustCreditResponse
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public long Ts { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public bool Data { get; set; }
    }
}