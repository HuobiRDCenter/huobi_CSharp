using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class SubUserTransferabilityResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Transferability[] Data;
        
        public class Transferability
        {
            [JsonProperty("subUid", NullValueHandling = NullValueHandling.Ignore)]
            public long SubUid;

            [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountType;

            [JsonProperty("transferrable", NullValueHandling = NullValueHandling.Ignore)]
            public bool Transferrable;

            [JsonProperty("errCode", NullValueHandling = NullValueHandling.Ignore)]
            public int ErrCode;

            [JsonProperty("errMessage", NullValueHandling = NullValueHandling.Ignore)]
            public string ErrMessage;
        }
    }
}