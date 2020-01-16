using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request
{
    public class BatchCancelOrdersByAccountIdRequest
    {
        [JsonProperty(PropertyName = "account-id")]
        public string AccountId;

        public string symbol;

        public string side;

        public int size;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
