namespace Huobi.SDK.Model.Response.Common
{
    public class GetMarketStatusResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        /// <summary>
        /// Error message (if any)
        /// </summary>
        public string message;

        /// <summary>
        /// Response body
        /// </summary>
        public Status data;

        public class Status
        {
            /// <summary>
            /// Market status (1=normal, 2=halted, 3=cancel-only)
            /// </summary>
            public int marketStatus;

            /// <summary>
            /// Halt start time (unix time in millisecond) , only valid for marketStatus=halted or cancel-only
            /// </summary>
            public long haltStartTime;

            /// <summary>
            /// Estimated halt end time (unix time in millisecond) , only valid for marketStatus=halted or cancel-only;
            /// if this field is not returned during marketStatus=halted or cancel-only,
            /// it implicates the halt end time cannot be estimated at this time.
            /// </summary>
            public long haltEndTime;

            /// <summary>
            /// Halt reason (2=emergency-maintenance, 3=scheduled-maintenance) , only valid for marketStatus=halted or cancel-only
            /// </summary>
            public int haltReason;

            /// <summary>
            /// Affected symbols, separated by comma. If affect all symbols just respond with value ‘all’.
            /// Only valid for marketStatus=halted or cancel-only
            /// </summary>
            public string affectedSmbols;
        }
    }
}
