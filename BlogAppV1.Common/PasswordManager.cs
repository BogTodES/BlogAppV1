using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BlogAppV1.Common
{
    public static class PasswordManager
    {
        public static byte[] HashPassword(string inputPass, ref string result)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: inputPass,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            result = hashedPass;
            return salt;
        }

        public static bool Match(string password, string test, byte[] salts)
        {
            password = password.Trim();
            test = test.Trim();

            return HashWithSalts(password, salts) == test;
        }

        private static string HashWithSalts(string pass, byte[] salts)
        {
            var hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pass,
            salt: salts,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashedPass;
        }
    }
}
