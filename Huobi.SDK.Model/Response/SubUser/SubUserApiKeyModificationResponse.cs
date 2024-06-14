using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserApiKeyModificationResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public ApiKeyModification Data;
        
        public class ApiKeyModification
        {
            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public string Note;

            [JsonProperty("permission", NullValueHandling = NullValueHandling.Ignore)]
            public string Permission;

            [JsonProperty("ipAddresses", NullValueHandling = NullValueHandling.Ignore)]
            public string IpAddresses;
        }
    }
}