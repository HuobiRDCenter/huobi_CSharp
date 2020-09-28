using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request.Account
{
    public class TransferPointRequest
    {
        public string fromUid;

        public string toUid;

        public long groupId;

        public string amount;
        
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
