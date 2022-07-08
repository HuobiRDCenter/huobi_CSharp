using Newtonsoft.Json;

namespace HuobiSDK.Model.Request.Account
{
    public class TransferAccountRequest
    {
        [JsonProperty("from-user")]
        public long fromUser;

        [JsonProperty("from-account-type")]
        public string fromAccountType;

        [JsonProperty("from-account")]
        public long fromAccount;

        [JsonProperty("to-user")]
        public long toUser;

        [JsonProperty("to-account-type")]
        public string toAccountType;

        [JsonProperty("to-account")]
        public long toAccount;

        public string currency;

        public string amount;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
