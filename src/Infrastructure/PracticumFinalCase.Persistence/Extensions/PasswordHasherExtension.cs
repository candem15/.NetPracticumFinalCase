using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Persistence.Extensions
{
    // Kullanıcıların şifrelerini db de güvenli bir şekilde tutmak için Salting ve hashing extensionu.
    public static class PasswordHasherExtension
    {
        const int keySize = 64;
        const int iterations = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        // Şifre hashleme methodu
        public static string HashPasword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash) + Convert.ToHexString(salt);
        }

        // Login işlemi için şifre doğrulayıcı method
        public static bool VerifyPassword(string password, string hash)
        {
            // Getting "Salt" value from stored password hash.
            byte[] salt = Convert.FromHexString(hash.Substring(128, 128));

            //Seperating password hash from salted Hash.
            var existingHash = hash.Substring(0, 128);

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(existingHash));
        }
    }
}
