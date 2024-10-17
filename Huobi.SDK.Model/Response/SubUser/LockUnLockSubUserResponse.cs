namespace Huobi.SDK.Model.Response.SubUser
{
    /// <summary>
    /// LockSubUser and UnLockSubUser Response
    /// </summary>
    public class LockUnLockSubUserResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public int code;

        public State data;

        public class State
        {
            /// <summary>
            /// sub user id
            /// </summary>
            public int subUid;

            /// <summary>
            /// sub user state
            /// </summary>
            public string userState;
        }
    }
}