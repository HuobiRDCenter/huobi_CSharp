using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class GetSubUserApiKeyResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public APIKeyData[] Data;
        
        public class APIKeyData
        {
            [JsonProperty("accessKey", NullValueHandling = NullValueHandling.Ignore)]
            public string AccessKey;

            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public string Note;

            [JsonProperty("permission", NullValueHandling = NullValueHandling.Ignore)]
            public string Permission;

            [JsonProperty("ipAddresses", NullValueHandling = NullValueHandling.Ignore)]
            public string IPAddresses;

            [JsonProperty("validDays", NullValueHandling = NullValueHandling.Ignore)]
            public int ValidDays;

            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            public string Status;

            [JsonProperty("createTime", NullValueHandling = NullValueHandling.Ignore)]
            public long CreateTime;

            [JsonProperty("updateTime", NullValueHandling = NullValueHandling.Ignore)]
            public long UpdateTime;
        }
    }
}