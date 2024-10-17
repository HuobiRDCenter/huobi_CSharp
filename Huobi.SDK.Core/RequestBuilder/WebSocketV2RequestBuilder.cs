using System;
using Huobi.SDK.Core.Model;

namespace Huobi.SDK.Core.RequestBuilder
{
    public class WebSocketV2RequestBuilder
    {
        private readonly string _host;
        private readonly string _path;
private const string _sMVaue2 = "ED25519";
        private const string _aKKey = "accessKey";
        private readonly string _aKValue;
        private const string _sMKey = "signatureMethod";
        private const string _sMVaue = "HmacSHA256";
        private const string _sVKey = "signatureVersion";
        private const string _sVValue = "2.1";
        private const string _tKey = "timestamp";
 private readonly string _sign;
        private Signer _signer;
 private readonly Ed25519Signer _signer255;
        public WebSocketV2RequestBuilder(string accessKey, string secretKey, string host, string path,string sign)
        {
            _sign=sign;
            _aKValue = accessKey;
             if(sign=="256"){
                _signer = new Signer(secretKey);
                _signer255=null;

            }else{
                _signer=null;
                _signer255 = new Ed25519Signer(secretKey);
                
            }
            

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
                
                .AddParam(_sVKey, _sVValue)
                .AddParam(_tKey, strDateTime);

            if(_sign=="256"){
                request .AddParam(_sMKey, _sMVaue);;

            }else{
                request .AddParam(_sMKey, _sMVaue2);
                
            }
            // string signature = _signer.Sign("GET", _host, _path, request.BuildParams());

             string signature;
            if(_sign=="256"){
 signature= _signer.Sign("GET", _host, _path, request.BuildParams());
            }else{
//  signature = _signer255.Sign("GET", _host, _path, request.BuildParams());
signature = _signer255.Sign("GET" + "\n" + _host + "\n" + _path + "\n" + request.BuildParams());
            }
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
