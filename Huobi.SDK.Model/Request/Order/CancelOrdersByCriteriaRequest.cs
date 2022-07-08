using Newtonsoft.Json;

namespace HuobiSDK.Model.Request.Order
{
    public class CancelOrdersByCriteriaRequest
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
