using Newtonsoft.Json;

namespace HuobiSDK.Model.Request.Wallet
{
    public class WithdrawRequest
    {
        public string address;

        public string amount;

        public string currency;

        public string fee;

        public string chain;

        public string addrTag;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
