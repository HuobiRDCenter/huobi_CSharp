﻿using Microsoft.Extensions.Configuration;

namespace Huobi.SDK.Example
{
    public class Config
    {
        // The shared keys and ids that used for all the examples
        public static string Host { get; private set; }
        public static string AccessKey { get; private set; }
        public static string PublicKey { get; private set; }
        public static string PrivateKey { get; private set; }
        public static string SecretKey { get; private set; }
        public static string AccountId { get; private set; }
        public static string SubUserId { get; private set; }
        public static string Sign { get; private set; }

        /// <summary>
        /// Load Accesskey and AccountId from 'appsettings.json' and SecretKey from 'key.json'.
        /// 
        /// To prevent submitting SecretKey into repository by accident, the 'key.json' file
        /// is already added in the .gitignore file
        /// 
        /// You should create the key.json file and include it into your solution with below definition
        /// 
        /// {
        ///     "SecretKey": "xxxx-xxxx-xxxx-xxxx"
        /// }
        ///
        /// </summary>
        public static void LoadConfig()
        {
            // Read configs from 'appsettings.json'
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Host = config["Host"];
            AccessKey = config["AccessKey"];
            AccountId = config["AccountId"];
            SubUserId = config["SubUserId"];
            Sign=config["Sign"];
            PrivateKey=config["PrivateKey"];
            PublicKey=config["PublicKey"];

            // Read SecretKey from 'key.json'
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SecretKey = config["SecretKey"];
        }
    }
}
