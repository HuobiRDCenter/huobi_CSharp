using System;

namespace Huobi.SDK.Core.RequestBuilder
{
    public class PrivateUrlBuilder
    {
        private readonly string _host;

         private readonly string _sign;

        private const string _aKKey = "AccessKeyId";
        private readonly string _aKValue;
        private const string _sMKey = "SignatureMethod";
        private const string _sMVaue = "HmacSHA256";

        private const string _sMVaue2 = "Ed25519";
        private const string _sVKey = "SignatureVersion";
        private const string _sVValue = "2";
        private const string _tKey = "Timestamp";
       
        private readonly Signer _signer;
        private readonly Ed25519Signer _signer255;

        public PrivateUrlBuilder(string accessKey, string secretKey, string host,string sign)
        {
            _aKValue = accessKey;
            _sign=sign;
            if(sign=="256"){
                _signer = new Signer(secretKey);
                _signer255=null;

            }else{
                _signer=null;
                _signer255 = new Ed25519Signer(secretKey);
                
            }
            
            _host = host;
        }

        public string Build(string method, string path)
        {
            return Build(method, path, DateTime.UtcNow, null);
        }

        public string Build(string method, string path, DateTime utcDateTime)
        {
            return Build(method, path, utcDateTime, null);
        }
        
        public string Build(string method, string path, GetRequest request)
        {
            return Build(method, path, DateTime.UtcNow, request);
        }

        public string Build(string method, string path, DateTime utcDateTime, GetRequest request)
        {
            string strDateTime = utcDateTime.ToString("yyyy-MM-ddTHH:mm:ss");

            var req = new GetRequest(request).
                AddParam(_aKKey, _aKValue)
                .AddParam(_sVKey, _sVValue);

            if(_sign=="256"){
                req .AddParam(_sMKey, _sMVaue).AddParam(_tKey, strDateTime)
                ;
            }else{
                req .AddParam(_sMKey, _sMVaue2).AddParam(_tKey, strDateTime)
                ;
            }
            
            // Console.WriteLine("req.BuildParams()"+req.BuildParams());
            

            string signature;
            if(_sign=="256"){
                    signature= _signer.Sign(method, _host, path, req.BuildParams());
            }else{
                    signature = _signer255.Sign(method + "\n" + _host + "\n" + path + "\n" + req.BuildParams());
            }
            

            string url = $"https://{_host}{path}?{req.BuildParams()}&Signature={Uri.EscapeDataString(signature)}";
            Console.WriteLine(url);
            
            return url;
        }
    }
}
