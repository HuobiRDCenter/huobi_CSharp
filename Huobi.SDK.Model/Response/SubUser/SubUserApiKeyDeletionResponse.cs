using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserApiKeyDeletionResponse
    {
        public int code;
        
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string data;
    }
}