using System;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    internal static class Encryptor
    {
        private const string Salt = "SocialNetworkPasswordSalt";

        internal static string GetMd5Hash(string input)
        {
            var hmacMd5 = new HMACMD5(Encoding.UTF8.GetBytes(Salt));
            var saltedHash = hmacMd5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(saltedHash);
        }

        internal static bool VerifyMd5Hash(string input, string hash)
        {
            string inputHash = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(inputHash, hash) == 0;
        }
    }
}
