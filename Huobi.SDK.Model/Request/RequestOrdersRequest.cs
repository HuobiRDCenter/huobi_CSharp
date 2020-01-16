using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request
{
    public class RequestOrdersRequest
    {
        public string op { get { return "req"; } }

        public string topic { get { return "orders.list"; } }

        public string cid;

        [JsonProperty(PropertyName = "account-id")]
        public int AccountId;

        public string symbol;

        public string types;

        public string states;

        [JsonProperty(PropertyName = "start-date")]
        public string StartDate;

        [JsonProperty(PropertyName = "end-date")]
        public string EndDate;

        public string from;

        public string direct;

        public string size;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
