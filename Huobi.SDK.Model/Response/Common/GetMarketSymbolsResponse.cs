using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetMarketSymbolsResponse
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public MarketSymbols[] Data;

        public class MarketSymbols
        {
            [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
            public string Symbol;

            [JsonProperty("bc", NullValueHandling = NullValueHandling.Ignore)]
            public string Bc;

            [JsonProperty("qc", NullValueHandling = NullValueHandling.Ignore)]
            public string Qc;

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string State;

            [JsonProperty("sp", NullValueHandling = NullValueHandling.Ignore)]
            public string Sp;

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public string Tags;

            [JsonProperty("lr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Lr;

            [JsonProperty("smlr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Smlr;

            [JsonProperty("pp", NullValueHandling = NullValueHandling.Ignore)]
            public int Pp;

            [JsonProperty("ap", NullValueHandling = NullValueHandling.Ignore)]
            public int Ap;

            [JsonProperty("vp", NullValueHandling = NullValueHandling.Ignore)]
            public int Vp;

            [JsonProperty("minoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Minoa;

            [JsonProperty("maxoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Maxoa;

            [JsonProperty("minov", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Minov;

            [JsonProperty("lominoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Lominoa;

            [JsonProperty("lomaxoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Lomaxoa;

            [JsonProperty("lomaxba", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Lomaxba;

            [JsonProperty("lomaxsa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Lomaxsa;

            [JsonProperty("smminoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Smminoa;

            [JsonProperty("smmaxoa", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Smmaxoa;

            [JsonProperty("bmmaxov", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Bmmaxov;

            [JsonProperty("blmlt", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Blmlt;

            [JsonProperty("slmgt", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Slmgt;

            [JsonProperty("msormlt", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Msormlt;

            [JsonProperty("mbormlt", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Mbormlt;

            [JsonProperty("at", NullValueHandling = NullValueHandling.Ignore)]
            public string At;

            [JsonProperty("u", NullValueHandling = NullValueHandling.Ignore)]
            public string U;

            [JsonProperty("mfr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Mfr;

            [JsonProperty("ct", NullValueHandling = NullValueHandling.Ignore)]
            public string Ct;

            [JsonProperty("rt", NullValueHandling = NullValueHandling.Ignore)]
            public string Rt;

            [JsonProperty("rthr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Rthr;

            [JsonProperty("in", NullValueHandling = NullValueHandling.Ignore)]
            public decimal In;

            [JsonProperty("maxov", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Maxov;

            [JsonProperty("flr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal Flr;

            [JsonProperty("castate", NullValueHandling = NullValueHandling.Ignore)]
            public string Castate;
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