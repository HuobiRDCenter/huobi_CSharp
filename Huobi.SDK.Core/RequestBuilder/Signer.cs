using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
// using NSec.Cryptography;
using System.IO;

using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO.Pem;
namespace Huobi.SDK.Core.RequestBuilder
{
    /// <summary>
    /// Responsible for generating signatures
    /// </summary>
    public class Signer : IDisposable

    {
        private HMACSHA256 _hmacsha256;
        public Signer(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty", nameof(key));
            }

            byte[] keyBuffer = Encoding.UTF8.GetBytes(key);
            _hmacsha256 = new HMACSHA256(keyBuffer);
        }

        public virtual string Sign(string method, string host, string path, string parameters)
        {
            if (string.IsNullOrEmpty(method) || string.IsNullOrEmpty(host) || string.IsNullOrEmpty(path) || string.IsNullOrEmpty(parameters))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
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
        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _hmacsha256.Dispose();
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

   public class Ed25519Signer : IDisposable
{
    private readonly Ed25519PrivateKeyParameters _privateKey;
    private readonly Org.BouncyCastle.Crypto.Signers.Ed25519Signer _signer;

    public Ed25519Signer(string base64PrivateKey)
    {
         // 从 PEM 格式解析私钥
        using (var stringReader = new StringReader(base64PrivateKey))
        {
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(stringReader);
            var keyObject = pemReader.ReadObject();

            // 确保读取到 Ed25519PrivateKeyParameters 类型
            if (keyObject is Ed25519PrivateKeyParameters privateKeyParams)
            {
                _privateKey = privateKeyParams;
                //  Console.WriteLine("Private Key Bytes: " + BitConverter.ToString(_privateKey.GetEncoded()).Replace("-", ""));
            }
            else
            {
                throw new InvalidCastException("Unable to cast PEM object to Ed25519PrivateKeyParameters.");
            }
        }
        // Console.WriteLine("Private Key Bytes: " + BitConverter.ToString(_privateKey.GetEncoded()).Replace("-", ""));

        _signer = new Org.BouncyCastle.Crypto.Signers.Ed25519Signer();
        _signer.Init(true, _privateKey);
    }

   
    public string Sign(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("Message cannot be null or empty", nameof(message));
        }
        Console.WriteLine(message);

        // 更新消息
        _signer.BlockUpdate(Encoding.UTF8.GetBytes(message), 0, message.Length);
        
        // 生成签名
        byte[] signatureBytes = _signer.GenerateSignature();
        return Convert.ToBase64String(signatureBytes);
    }

    #region IDisposable Support
    private bool _isDisposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                // 释放资源（如果有）
            }
            _isDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
   
}

