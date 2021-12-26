using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace task4
{
    class Confirmation
    {
        public string CreateRandomKey()
        {
            StringBuilder her = new StringBuilder();
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[32];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            foreach (Byte b in randomBytes)
                her.Append(b.ToString("x2"));

            return her.ToString().ToUpper();
        }

        public string CreateHMAC(string text, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(encoding.GetBytes(key)))
                hashBytes = hash.ComputeHash(encoding.GetBytes(text));

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
