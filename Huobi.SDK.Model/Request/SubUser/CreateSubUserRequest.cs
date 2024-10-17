using Newtonsoft.Json;

namespace Huobi.SDK.Model.Request.SubUser
{
    /// <summary>
    /// Create SubUser request
    /// </summary>
    public class CreateSubUserRequest
    {
        public UserList[] userList;

        public class UserList
        {
            public string userName;

            public string note;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
