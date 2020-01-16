using Microsoft.Extensions.Configuration;

namespace Huobi.SDK.Example
{
    public class APIKey
    {
        // The shared keys and ids that used for all the examples
        public static string AccessKey { get; private set; }
        public static string SecretKey { get; private set; }
        public static string AccountId { get; private set; }

        /// <summary>
        /// Load Accesskey and AccountId from 'appsettings.json' and SecretKey from 'key.json'.
        /// 
        /// To prevent submitting SecretKey into repository by accident, the 'key.json' file
        /// is added in the .gitignore file
        /// 
        /// You should create the key.json file and include it into your solution with below definition
        /// 
        /// {
        ///     "SecretKey": "xxxx-xxxx-xxxx-xxxx"
        /// }
        ///
        /// </summary>
        public static void LoadAPIKey()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            AccessKey = config["AccessKey"];
            AccountId = config["AccountId"];

            config = new ConfigurationBuilder().AddJsonFile("key.json").Build();

            SecretKey = config["SecretKey"];
        }
    }
}
