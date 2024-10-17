using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class DeductModeSubUserResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public DeductModeSubUser[] Data;
        
        public class DeductModeSubUser
        {
            [JsonProperty("subUid", NullValueHandling = NullValueHandling.Ignore)]
            public string SubUid;

            [JsonProperty("deductMode", NullValueHandling = NullValueHandling.Ignore)]
            public string DeductMode;

            [JsonProperty("errCode", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrCode;

            [JsonProperty("errMessage", NullValueHandling = NullValueHandling.Ignore)]
            public string errMessage;
        }
    }
}