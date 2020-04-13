namespace Huobi.SDK.Log
{
    public struct LogContent
    {
        public int Id;
        public string Endpoint;
        public string Url;
        public long TotalDuration;
        public long NetworkDuration;
        public long SDKDuration;
    }
}
