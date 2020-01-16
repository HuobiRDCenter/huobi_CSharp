using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request
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
