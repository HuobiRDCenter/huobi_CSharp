using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserApiKeyGenerationResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public ApiKeyGeneration Data;
        
        public class ApiKeyGeneration
        {
            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public string Note;

            [JsonProperty("accessKey", NullValueHandling = NullValueHandling.Ignore)]
            public string AccessKey;

            [JsonProperty("secretKey", NullValueHandling = NullValueHandling.Ignore)]
            public string SecretKey;

            [JsonProperty("permission", NullValueHandling = NullValueHandling.Ignore)]
            public string Permission;

            [JsonProperty("ipAddresses", NullValueHandling = NullValueHandling.Ignore)]
            public string IpAddresses;
        }
    }
}