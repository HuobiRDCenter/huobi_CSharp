using System;
using System.Security.Cryptography;
using System.Text;

namespace Huobi.SDK.Core.RequestBuilder
{
    /// <summary>
    /// Responsible to generate signature
    /// </summary>
    public class Signer : IDisposable
    {
        HMACSHA256 _hmacsha256;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">The secrect key that is used to sign</param>
        public Signer(string key)
        {
            byte[] keyBuffer = Encoding.UTF8.GetBytes(key);
            _hmacsha256 = new HMACSHA256(keyBuffer);
        }

        /// <summary>
        /// Generate sigature
        /// </summary>
        /// <param name="method">HTTP method, use "GET" for websocket</param>
        /// <param name="host">Host name</param>
        /// <param name="path">Path</param>
        /// <param name="parameters">Parameter pairs</param>
        /// <returns></returns>
        public string Sign(string method, string host, string path, string parameters)
        {
            if (string.IsNullOrEmpty(method) || string.IsNullOrEmpty(host)
                || string.IsNullOrEmpty(path) || string.IsNullOrEmpty(parameters))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append($"{method}\n");
            sb.Append($"{host}\n");
            sb.Append($"{path}\n");
            sb.Append(parameters);

            return Sign(sb.ToString());
        }

        private string Sign(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            byte[] inputBuffer = Encoding.UTF8.GetBytes(input);

            byte[] hashedBuffer = _hmacsha256.ComputeHash(inputBuffer);

            return Convert.ToBase64String(hashedBuffer);
        }

        #region IDisposable Support
        private bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _hmacsha256.Dispose();
                }

                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion


    }
}
