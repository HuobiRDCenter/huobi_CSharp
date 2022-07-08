using Newtonsoft.Json;

namespace HuobiSDK.Model.Request.Order
{
    public class CancelOrdersByIdsRequest
    {
        [JsonProperty(PropertyName = "order-ids")]
        public string[] OrderIds;

        [JsonProperty(PropertyName = "client-order-ids")]
        public string[] ClientOrderIds;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
