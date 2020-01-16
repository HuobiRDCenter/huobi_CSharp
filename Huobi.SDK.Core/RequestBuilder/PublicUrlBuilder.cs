namespace Huobi.SDK.Core.RequestBuilder
{
    public class PublicUrlBuilder
    {
        private readonly string _host;

        public PublicUrlBuilder(string host)
        {
            _host = host;
        }

        public string Build(string path, RequestParammeters reqParams = null)
        {
            if (reqParams != null)
            {
                return $"https://{_host}{path}?{reqParams.BuildParams()}";
            }
            else
            {
                return $"https://{_host}{path}";
            }
        }
    }
}
