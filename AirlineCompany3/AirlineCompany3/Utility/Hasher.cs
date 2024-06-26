using System;
using System.Security.Cryptography;
using System.Text;

namespace AirlineCompany3.Utility
{
    public static class Hasher
    {
        public static string Hash(string entry)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(entry));
                return BytesToHex(bytes);
            }
        }

        private static string BytesToHex(byte[] hash)
        {
            StringBuilder hexString = new StringBuilder(2 * hash.Length);
            foreach (byte b in hash)
            {
                string hex = b.ToString("x2");
                hexString.Append(hex);
            }
            return hexString.ToString();
        }
    }
}
