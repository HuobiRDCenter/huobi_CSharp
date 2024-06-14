using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetCurrenciesV2Response
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public CurrenciesV2[] data;

        public class CurrenciesV2
        {
            [JsonProperty("cc", NullValueHandling = NullValueHandling.Ignore)]
            public string cc;

            [JsonProperty("dn", NullValueHandling = NullValueHandling.Ignore)]
            public string dn;

            [JsonProperty("fn", NullValueHandling = NullValueHandling.Ignore)]
            public string fn;

            [JsonProperty("at", NullValueHandling = NullValueHandling.Ignore)]
            public int at;

            [JsonProperty("wp", NullValueHandling = NullValueHandling.Ignore)]
            public int wp;

            [JsonProperty("ft", NullValueHandling = NullValueHandling.Ignore)]
            public string ft;

            [JsonProperty("dma", NullValueHandling = NullValueHandling.Ignore)]
            public string dma;

            [JsonProperty("wma", NullValueHandling = NullValueHandling.Ignore)]
            public string wma;

            [JsonProperty("sp", NullValueHandling = NullValueHandling.Ignore)]
            public string sp;

            [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
            public string w;

            [JsonProperty("qc", NullValueHandling = NullValueHandling.Ignore)]
            public bool qc;

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string state;

            [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
            public bool v;

            [JsonProperty("whe", NullValueHandling = NullValueHandling.Ignore)]
            public bool whe;

            [JsonProperty("cd", NullValueHandling = NullValueHandling.Ignore)]
            public bool cd;

            [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
            public bool de;

            [JsonProperty("wed", NullValueHandling = NullValueHandling.Ignore)]
            public bool wed;

            [JsonProperty("cawt", NullValueHandling = NullValueHandling.Ignore)]
            public bool cawt;

            [JsonProperty("fc", NullValueHandling = NullValueHandling.Ignore)]
            public int fc;

            [JsonProperty("sc", NullValueHandling = NullValueHandling.Ignore)]
            public int sc;

            [JsonProperty("swd", NullValueHandling = NullValueHandling.Ignore)]
            public string swd;

            [JsonProperty("wd", NullValueHandling = NullValueHandling.Ignore)]
            public string wd;

            [JsonProperty("sdd", NullValueHandling = NullValueHandling.Ignore)]
            public string sdd;

            [JsonProperty("dd", NullValueHandling = NullValueHandling.Ignore)]
            public string dd;

            [JsonProperty("svd", NullValueHandling = NullValueHandling.Ignore)]
            public string svd;

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public string tags;
        }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public string ts;

        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
        public int full;

        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string err_code;

        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string err_msg;
    }
}