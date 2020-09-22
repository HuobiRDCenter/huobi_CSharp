using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request
{
    public class PostRequestBase
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
