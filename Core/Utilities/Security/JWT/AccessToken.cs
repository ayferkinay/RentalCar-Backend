using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //erişim anahtarı
    {
        public string Token { get; set; } //anlamsız karakterlerden oluşan anahtar(token) değeridir
        public DateTime Expiration { get; set; } //Kullanıcıya Token verirken tokenin hangi tarhite biteceği verirlir
    }
}
