using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request
{
    public class BatchCancelOrdersByOrderIdRequest
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
