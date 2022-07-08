using Newtonsoft.Json;

namespace HuobiSDK.Model.Request
{
    public class PostRequestBase
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
