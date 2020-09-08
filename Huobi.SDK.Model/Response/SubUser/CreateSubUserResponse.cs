namespace Huobi.SDK.Model.Response.SubUser
{
    /// <summary>
    /// Create SubUser Response
    /// </summary>
    public class CreateSubUserResponse
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
        public Creation[] data;

        public class Creation
        {
            public string userName;

            public string note;

            public long uid;

            public string errCode;

            public string errMessage;
        }
    }
}
