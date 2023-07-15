namespace HuobiSDK.Core.Model
{
    public class PingMessageV2
    {
        public class Data
        {
            public long ts;
        }

        public string action;
        public Data data;
    }
}
