using System;
using HuobiSDK.Core.Model;

namespace HuobiSDK.Core.RequestBuilder
{
    public class WebSocketV2RequestBuilder
    {
        private readonly string _host;
        private readonly string _path;

        private const string _aKKey = "accessKey";
        private readonly string _aKValue;
        private const string _sMKey = "signatureMethod";
        private const string _sMVaue = "HmacSHA256";
        private const string _sVKey = "signatureVersion";
        private const string _sVValue = "2.1";
        private const string _tKey = "timestamp";

        private Signer _signer;

        public WebSocketV2RequestBuilder(string accessKey, string secretKey, string host, string path)
        {
            _aKValue = accessKey;
            _signer = new Signer(secretKey);

            _host = host;
            _path = path;
        }

        public string Build()
        {
            return Build(DateTime.UtcNow);
        }

        public string Build(DateTime utcDateTime)
        {
            string strDateTime = utcDateTime.ToString("s");

            var request = new GetRequest()
                .AddParam(_aKKey, _aKValue)
                .AddParam(_sMKey, _sMVaue)
                .AddParam(_sVKey, _sVValue)
                .AddParam(_tKey, strDateTime);

            string signature = _signer.Sign("GET", _host, _path, request.BuildParams());

            var auth = new WebSocketAuthenticationRequestV2
            {
                @params = new WebSocketAuthenticationRequestV2.Params
                {
                    accessKey = _aKValue,
                    timestamp = strDateTime,
                    signature = signature
                }
            };

            return auth.ToJson();
        }
    }
}
