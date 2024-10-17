using System;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.Model
{
    public class WebSocketAuthenticationRequestV2
    {
        public class Params
        {
            public string authType { get { return "api"; } }
            public string accessKey;
            public string signatureMethod { get { return "HmacSHA256"; } }
            public string signatureVersion { get { return "2.1"; } }
            public string timestamp;
            public string signature;
        }

        public string action { get { return "req"; } }
        public string ch { get { return "auth"; } }
        public Params @params;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
