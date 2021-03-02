using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)//void yaptık ve yinede out ile son 2 tanesinin değerini değiştirip dışarı verdik.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//Hazır algoritmalardan birini şeçtik, her kullanıcı için yeni bir Key değeri tutar bu...
            {
                passwordSalt = hmac.Key; //alogritmanın keyini kullanmayı tercih ettik salt için.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//direk ona generate ettirdik hash codunu
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//passwordSalt ile beraber koyulmuş oldu.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//tekrar aynı yolla hash üretilir.Encoding ile byte türüne getirilmiş olur.
                for (int i = 0; i < computedHash.Length; i++) //forla tüm değerler alındı.
                {
                    if (computedHash[i] != passwordHash[i]) //değerlerini kontrol ettik.
                    {
                        return false;
                    }
                    
                }
                return true;
            }
        }
    }
}
