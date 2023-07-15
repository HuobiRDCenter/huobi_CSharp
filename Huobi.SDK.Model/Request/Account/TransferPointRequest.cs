using Newtonsoft.Json;

namespace HuobiSDK.Model.Request.Account
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
