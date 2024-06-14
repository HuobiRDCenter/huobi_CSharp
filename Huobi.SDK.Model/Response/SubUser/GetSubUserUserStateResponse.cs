using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class GetSubUserUserStateResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public UserStateData Data;
        
        public class UserStateData
        {
            [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
            public long Uid;

            [JsonProperty("userState", NullValueHandling = NullValueHandling.Ignore)]
            public string UserState;
        }
    }
}