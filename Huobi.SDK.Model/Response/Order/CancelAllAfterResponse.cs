using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Order
{
    public class CancelAllAfterResponse
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code;

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message;

        [JsonProperty("<data>", NullValueHandling = NullValueHandling.Ignore)]
        public CancelAllAfter Data;
        
        public class CancelAllAfter
        {
            [JsonProperty("currentTime", NullValueHandling = NullValueHandling.Ignore)]
            public long CurrentTime;

            [JsonProperty("triggerTime", NullValueHandling = NullValueHandling.Ignore)]
            public long TriggerTime;
        }
    }
}