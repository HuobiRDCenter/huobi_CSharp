using Newtonsoft.Json;

namespace Huobi.SDK.Core.Model
{
    public class WebSocketAuthenticationRequest
    {
        public string op { get { return "auth"; } }
        public string AccessKeyId;
        public string SignatureMethod { get { return "HmacSHA256"; } }
        public string SignatureVersion { get { return "2"; } }
        public string Timestamp;
        public string Signature;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
