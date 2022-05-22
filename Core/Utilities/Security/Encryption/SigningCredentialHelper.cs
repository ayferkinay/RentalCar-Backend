using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {

        //bizim için jwt servislerinin oluşturulabilmesi için mesela kullanıcı adı ve parola credential dır yani bir sisteme girebilmek için elimizde olanlardır
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //burda hangi anahtar ve hangi algoritma kullanılacak onu belirtiyoruz
        }
    }
}
