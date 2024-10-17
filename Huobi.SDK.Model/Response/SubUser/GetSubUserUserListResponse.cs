using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.SubUser
{
    public class GetSubUserUserListResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public SubUserUserList Data;

        [JsonProperty("nextId", NullValueHandling = NullValueHandling.Ignore)]
        public long NextId;
        
        public class SubUserUserList
        {
            [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
            public long Uid;

            [JsonProperty("userState", NullValueHandling = NullValueHandling.Ignore)]
            public string UserState;

            [JsonProperty("subUserName", NullValueHandling = NullValueHandling.Ignore)]
            public string SubUserName;

            [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
            public string Note;
        }
    }
}