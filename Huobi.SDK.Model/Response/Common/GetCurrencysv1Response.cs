using Newtonsoft.Json;

namespace Huobi.SDK.Model.Response.Common
{
    public class GetCurrencysv1Response
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status;

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Currencysv1[] Data;
        
        public class Currencysv1
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name;

            [JsonProperty("dn", NullValueHandling = NullValueHandling.Ignore)]
            public string DisplayName;

            [JsonProperty("vat", NullValueHandling = NullValueHandling.Ignore)]
            public long AssetVisibleStartTime;

            [JsonProperty("det", NullValueHandling = NullValueHandling.Ignore)]
            public long DepositEnableTime;

            [JsonProperty("wet", NullValueHandling = NullValueHandling.Ignore)]
            public long WithdrawEnableTime;

            [JsonProperty("wp", NullValueHandling = NullValueHandling.Ignore)]
            public int WithdrawPrecision;

            [JsonProperty("ct", NullValueHandling = NullValueHandling.Ignore)]
            public string FeeType;

            [JsonProperty("cp", NullValueHandling = NullValueHandling.Ignore)]
            public string SupportedPartition;

            [JsonProperty("ss", NullValueHandling = NullValueHandling.Ignore)]
            public string[] SupportedSites;

            [JsonProperty("oe", NullValueHandling = NullValueHandling.Ignore)]
            public int OpenEnable;

            [JsonProperty("dma", NullValueHandling = NullValueHandling.Ignore)]
            public string MinDepositAmount;

            [JsonProperty("wma", NullValueHandling = NullValueHandling.Ignore)]
            public string MinWithdrawAmount;

            [JsonProperty("sp", NullValueHandling = NullValueHandling.Ignore)]
            public string DisplayPrecision;

            [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
            public string Weight;

            [JsonProperty("qc", NullValueHandling = NullValueHandling.Ignore)]
            public bool QuoteCurrency;

            [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
            public string CurrencyState;

            [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
            public bool Visible;

            [JsonProperty("whe", NullValueHandling = NullValueHandling.Ignore)]
            public bool WhitelistUser;

            [JsonProperty("cd", NullValueHandling = NullValueHandling.Ignore)]
            public bool CountryBlacklist;

            [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
            public bool DepositEnable;

            [JsonProperty("we", NullValueHandling = NullValueHandling.Ignore)]
            public bool WithdrawEnable;

            [JsonProperty("cawt", NullValueHandling = NullValueHandling.Ignore)]
            public bool AddressWithTag;

            [JsonProperty("cao", NullValueHandling = NullValueHandling.Ignore)]
            public bool OneTimeAddress;

            [JsonProperty("fc", NullValueHandling = NullValueHandling.Ignore)]
            public int FastConfirmationBlocks;

            [JsonProperty("sc", NullValueHandling = NullValueHandling.Ignore)]
            public int SafeConfirmationBlocks;

            [JsonProperty("swd", NullValueHandling = NullValueHandling.Ignore)]
            public string WithdrawSuspendText;

            [JsonProperty("wd", NullValueHandling = NullValueHandling.Ignore)]
            public string WithdrawText;

            [JsonProperty("sdd", NullValueHandling = NullValueHandling.Ignore)]
            public string DepositSuspendText;

            [JsonProperty("dd", NullValueHandling = NullValueHandling.Ignore)]
            public string DepositText;

            [JsonProperty("svd", NullValueHandling = NullValueHandling.Ignore)]
            public string AssetSuspendText;

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public string Tags;

            [JsonProperty("fn", NullValueHandling = NullValueHandling.Ignore)]
            public string FullName;

            [JsonProperty("bc", NullValueHandling = NullValueHandling.Ignore)]
            public object BC;

            [JsonProperty("iqc", NullValueHandling = NullValueHandling.Ignore)]
            public object IQC;
        }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp;

        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
        public int FullIncrementalType;

        [JsonProperty("err-code", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode;

        [JsonProperty("err-msg", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage;
    }
}