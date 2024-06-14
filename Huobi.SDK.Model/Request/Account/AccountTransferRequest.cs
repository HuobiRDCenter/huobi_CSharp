using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request.Account
{
    public class AccountTransferRequest
    {
        public string from;

        public string to;

        public string currency;

        public float amount;
        
        [JsonProperty("margin-account")]
        public string marginAccount;
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}