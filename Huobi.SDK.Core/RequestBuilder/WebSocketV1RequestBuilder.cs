using System;
using HuobiSDK.Core.Model;

namespace HuobiSDK.Core.RequestBuilder
{
    public class WebSocketV1RequestBuilder
    {
        private readonly string _host;
        private readonly string _path;

        private const string _aKKey = "AccessKeyId";
        private readonly string _aKValue;
        private const string _sMKey = "SignatureMethod";
        private const string _sMVaue = "HmacSHA256";
        private const string _sVKey = "SignatureVersion";
        private const string _sVValue = "2";
        private const string _tKey = "Timestamp";

        private readonly Signer _signer;

        public WebSocketV1RequestBuilder(string accessKey, string secretKey, string host, string path)
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

            var auth = new WebSocketAuthenticationRequest
            {
                AccessKeyId = _aKValue,
                Timestamp = strDateTime,
                Signature = signature
            };

            return auth.ToJson();
        }
    }
}
