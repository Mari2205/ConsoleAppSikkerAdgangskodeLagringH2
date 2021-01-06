using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ConsoleAppSikkerAdgangskodeLagringH2
{
    class Hash
    {
        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        //private static byte[] Combine(byte[] first, byte[] second)
        //{
        //    byte[] ret = new byte[first.Length + second.Length];

        //    Buffer.BlockCopy(first, 0, ret, 0, first.Length);
        //    Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

        //    return ret;
        //}

        //public static byte[] GetMacMd5(byte[] getHashed, byte[] salt)
        //{
        //    using (MD5 md5 = MD5.Create())
        //    {
        //        return md5.ComputeHash(Combine(getHashed,salt));
        //    }
        //}

        public static byte[] HashPasswordWhitPBKDF2(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
            {
                return rfc2898.GetBytes(32);
            }
        }
    }
}
