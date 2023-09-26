using System.Security.Cryptography;
using System.Text;

namespace Utilitario
{
    public class EncriptacionPassword
    {
        const int keySize = 64;
        const int iterations = 350000;

        public static string HashPasword(string password)
        {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            string data = "Hello regasist!";
            byte[] salt = Encoding.UTF8.GetBytes(data);

            //byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            string data = "Hello regasist!";
            byte[] salt = Encoding.UTF8.GetBytes(data);
            //byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }

}
