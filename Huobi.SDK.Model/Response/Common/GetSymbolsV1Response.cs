using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetSymbolsV1Response
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;
        
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public SymbolsV1[] data;

        public class SymbolsV1
        {
            [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
            public string Symbol;

            [JsonProperty("sn", NullValueHandling = NullValueHandling.Ignore)]
            public string Sn;

            [JsonProperty("bc", NullValueHandling = NullValueHandling.Ignore)]
            public string Bc;

            [JsonProperty("qc", NullValueHandling = NullValueHandling.Ignore)]
            public string Qc;

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string State;

            [JsonProperty("ve", NullValueHandling = NullValueHandling.Ignore)]
            public bool Ve;

            [JsonProperty("we", NullValueHandling = NullValueHandling.Ignore)]
            public bool We;

            [JsonProperty("dl", NullValueHandling = NullValueHandling.Ignore)]
            public bool Dl;

            [JsonProperty("cd", NullValueHandling = NullValueHandling.Ignore)]
            public bool Cd;

            [JsonProperty("te", NullValueHandling = NullValueHandling.Ignore)]
            public bool Te;

            [JsonProperty("ce", NullValueHandling = NullValueHandling.Ignore)]
            public bool Ce;

            [JsonProperty("tet", NullValueHandling = NullValueHandling.Ignore)]
            public long Tet;

            [JsonProperty("toa", NullValueHandling = NullValueHandling.Ignore)]
            public long Toa;

            [JsonProperty("tca", NullValueHandling = NullValueHandling.Ignore)]
            public long Tca;

            [JsonProperty("voa", NullValueHandling = NullValueHandling.Ignore)]
            public long Voa;

            [JsonProperty("vca", NullValueHandling = NullValueHandling.Ignore)]
            public long Vca;

            [JsonProperty("sp", NullValueHandling = NullValueHandling.Ignore)]
            public string Sp;

            [JsonProperty("tm", NullValueHandling = NullValueHandling.Ignore)]
            public string Tm;

            [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
            public int W;

            [JsonProperty("ttp", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Ttp;

            [JsonProperty("tap", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Tap;

            [JsonProperty("tpp", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Tpp;

            [JsonProperty("fp", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Fp;

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public string Tags;

            [JsonProperty("bcdn", NullValueHandling = NullValueHandling.Ignore)]
            public string Bcdn;

            [JsonProperty("qcdn", NullValueHandling = NullValueHandling.Ignore)]
            public string Qcdn;

            [JsonProperty("elr", NullValueHandling = NullValueHandling.Ignore)]
            public string Elr;

            [JsonProperty("castate", NullValueHandling = NullValueHandling.Ignore)]
            public string Castate;

            [JsonProperty("ca1oa", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca1oa;

            [JsonProperty("ca1ca", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca1ca;

            [JsonProperty("ca2oa", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca2oa;

            [JsonProperty("ca2ca", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca2ca;
        }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public string Ts;

        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
        public int Full;

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrCode;

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrMsg;
    }
}