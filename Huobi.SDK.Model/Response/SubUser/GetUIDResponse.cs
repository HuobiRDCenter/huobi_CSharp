namespace HuobiSDK.Model.Response.SubUser
{
    /// <summary>
    /// Create SubUser Response
    /// </summary>
    public class GetUIDResponse
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
        public long? data;
    }
}
