using System;
using System.Security.Cryptography;
using System.Text;

namespace SearchConsole.MozApi
{
    public class MozAuthenticator
    {
        private const string HMAC_SHA1_ALGORITHM = "HmacSHA1";

        private static readonly Encoding Encoding = Encoding.UTF8;

        private static readonly char[] padding = { '=' };

        private readonly string _accessId;

        private readonly string _secretKey;

        private readonly long _expireInterval;

        public MozAuthenticator()
        {
            _accessId = "mozscape-adfe8a6927";
            _secretKey = "77bb68342aae282ffe95eebc875cf36a";
            _expireInterval = 300;
        }

        public MozAuthenticator(string accessId, string secretKey, long expireInterval)
        {
            _accessId = accessId;
            _secretKey = secretKey;
            _expireInterval = expireInterval;
        }

        public string getAnthenticationStr()
        {

            long expires = (DateTime.Now.Millisecond) / 1000 + _expireInterval;

            string stringToSign = _accessId + "\n" + expires;

            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);
            byte[] contentBytes = Encoding.UTF8.GetBytes(stringToSign);

            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = secretKeyBytes;

            byte[] final = hmacsha1.ComputeHash(contentBytes);

            string urlsafesignature = Convert.ToBase64String(final);

            var authenticationStr = "AccessID=" + _accessId +
                                    "&Expires=" + expires +
                                    "&Signature=" + urlsafesignature;
            return authenticationStr;
        }

    }
}