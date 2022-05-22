using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class ClaimsPrincipalExtensions
    {

        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)  //bir kişinin jwt ye gelen kişininin claimlerine ulaşmak için 
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();  //kişinin rollerine ulaşmal için
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
