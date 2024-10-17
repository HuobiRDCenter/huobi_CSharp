using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetChainsResponse
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Chains[] Data;

        public class Chains
        {
            [JsonProperty("adt", NullValueHandling = NullValueHandling.Ignore)]
            public bool Adt;

            [JsonProperty("ac", NullValueHandling = NullValueHandling.Ignore)]
            public string Ac;

            [JsonProperty("ao", NullValueHandling = NullValueHandling.Ignore)]
            public bool Ao;

            [JsonProperty("awt", NullValueHandling = NullValueHandling.Ignore)]
            public bool Awt;

            [JsonProperty("chain", NullValueHandling = NullValueHandling.Ignore)]
            public string Chain;

            [JsonProperty("ct", NullValueHandling = NullValueHandling.Ignore)]
            public string Ct;

            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string Code;

            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            public string Currency;

            [JsonProperty("deposit-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string DepositDesc;

            [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
            public bool De;

            [JsonProperty("dma", NullValueHandling = NullValueHandling.Ignore)]
            public string Dma;

            [JsonProperty("deposit-tips-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string DepositTipsDesc;

            [JsonProperty("dn", NullValueHandling = NullValueHandling.Ignore)]
            public string Dn;

            [JsonProperty("fc", NullValueHandling = NullValueHandling.Ignore)]
            public int Fc;

            [JsonProperty("ft", NullValueHandling = NullValueHandling.Ignore)]
            public string Ft;

            [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
            public int Default;

            [JsonProperty("replace-chain-info-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string ReplaceChainInfoDesc;

            [JsonProperty("replace-chain-notification-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string ReplaceChainNotificationDesc;

            [JsonProperty("replace-chain-popup-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string ReplaceChainPopupDesc;

            [JsonProperty("ca", NullValueHandling = NullValueHandling.Ignore)]
            public string Ca;

            [JsonProperty("cct", NullValueHandling = NullValueHandling.Ignore)]
            public int Cct;

            [JsonProperty("sc", NullValueHandling = NullValueHandling.Ignore)]
            public int Sc;

            [JsonProperty("sda", NullValueHandling = NullValueHandling.Ignore)]
            public string Sda;

            [JsonProperty("suspend-deposit-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string SuspendDepositDesc;

            [JsonProperty("swa", NullValueHandling = NullValueHandling.Ignore)]
            public string Swa;

            [JsonProperty("suspend-withdraw-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string SuspendWithdrawDesc;

            [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
            public bool V;

            [JsonProperty("withdraw-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string WithdrawDesc;

            [JsonProperty("we", NullValueHandling = NullValueHandling.Ignore)]
            public bool We;

            [JsonProperty("wma", NullValueHandling = NullValueHandling.Ignore)]
            public string Wma;

            [JsonProperty("wp", NullValueHandling = NullValueHandling.Ignore)]
            public int Wp;

            [JsonProperty("fn", NullValueHandling = NullValueHandling.Ignore)]
            public string Fn;

            [JsonProperty("withdraw-tips-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string WithdrawTipsDesc;

            [JsonProperty("suspend-visible-desc", NullValueHandling = NullValueHandling.Ignore)]
            public string SuspendVisibleDesc;
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