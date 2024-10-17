using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetSymbolsV2Response
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;
    
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public DataObject[] Data;
    
        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public string Ts;
    
        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
        public int Full;
    
        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode;
    
        [JsonProperty("err_msg", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage;
        
        public class DataObject {
            [JsonProperty("si", NullValueHandling = NullValueHandling.Ignore)]
            public string Si;
            
            [JsonProperty("scr", NullValueHandling = NullValueHandling.Ignore)]
            public string Scr;
            
            [JsonProperty("sc", NullValueHandling = NullValueHandling.Ignore)]
            public string Sc;
            
            [JsonProperty("dn", NullValueHandling = NullValueHandling.Ignore)]
            public string Dn;
            
            [JsonProperty("bc", NullValueHandling = NullValueHandling.Ignore)]
            public string Bc;
            
            [JsonProperty("bcdn", NullValueHandling = NullValueHandling.Ignore)]
            public string Bcdn;
            
            [JsonProperty("qc", NullValueHandling = NullValueHandling.Ignore)]
            public string Qc;
            
            [JsonProperty("qcdn", NullValueHandling = NullValueHandling.Ignore)]
            public string Qcdn;
            
            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string State;
            
            [JsonProperty("whe", NullValueHandling = NullValueHandling.Ignore)]
            public bool Whe;
            
            [JsonProperty("cd", NullValueHandling = NullValueHandling.Ignore)]
            public bool Cd;
            
            [JsonProperty("te", NullValueHandling = NullValueHandling.Ignore)]
            public bool Te;
            
            [JsonProperty("toa", NullValueHandling = NullValueHandling.Ignore)]
            public long Toa;
            
            [JsonProperty("sp", NullValueHandling = NullValueHandling.Ignore)]
            public string Sp;
            
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
            
            [JsonProperty("suspend_desc", NullValueHandling = NullValueHandling.Ignore)]
            public string SuspendDesc;
            
            [JsonProperty("transfer_board_desc", NullValueHandling = NullValueHandling.Ignore)]
            public string TransferBoardDesc;
            
            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public string Tags;
            
            [JsonProperty("lr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal? Lr;
            
            [JsonProperty("smlr", NullValueHandling = NullValueHandling.Ignore)]
            public decimal? Smlr;
            
            [JsonProperty("flr", NullValueHandling = NullValueHandling.Ignore)]
            public string Flr;
            
            [JsonProperty("wr", NullValueHandling = NullValueHandling.Ignore)]
            public string Wr;
            
            [JsonProperty("d", NullValueHandling = NullValueHandling.Ignore)]
            public int D;
            
            [JsonProperty("elr", NullValueHandling = NullValueHandling.Ignore)]
            public string Elr;
            
            [JsonProperty("p", NullValueHandling = NullValueHandling.Ignore)]
            public P[] p;
            
            [JsonProperty("castate", NullValueHandling = NullValueHandling.Ignore)]
            public string Castate;
            
            [JsonProperty("ca1oa", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca1oa;
            
            [JsonProperty("ca2oa", NullValueHandling = NullValueHandling.Ignore)]
            public long Ca2oa;

            public class P
            {
                [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
                public int Id;
                
                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public string Name;
                
                [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
                public int Weight;
            }
        }
    }
}