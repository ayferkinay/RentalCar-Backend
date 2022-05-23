using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
  public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //verilen passwordun hashi oluşuyo 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //salt bulmak için kullandığımız algoritmanın key değerini veriyoruz. algoritmanın o an oluşturduğu key değeridir. her kullanıcı için farklı oluşturur bu yüzden güvenlidir. Key değişmeyen bir anahtar olduğu için saltta bunu kullandık 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // bir string derğerin byte karşılığı computedhash : hesaplanan hash
            }
        }

        //create işleminde parametrelerde out vermemizin sebebi kendisi oluşturduğu değerleri oarametrelere atayacapı için bizim girdiğimiz bi değer yok 
        // verify kısmında out olmamasının sebebi ise zaten verify ederken hash ve salt değerlerini db den çekecek yani out olarak bi çıktı almamızı gerketiren bir şey yok .

                                                     //kullanıcının girdiği parola
       public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //veritabınındaki hash ile girilen hash eşit mi bunu kontrol ediyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
    }
}
