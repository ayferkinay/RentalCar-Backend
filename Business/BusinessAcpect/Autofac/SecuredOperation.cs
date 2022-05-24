using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Business.Constants;
using Core.Utilities.IoC;
using Core.Extensions;

namespace Business.BusinessAspect.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception 
    {
        private string[] _roles; 
        private IHttpContextAccessor _httpContextAccessor;   //IHttpContextAccessor : JWT ye istek gönderiyoruz her istek için bir http context oluşuyor. bu br interface dir. 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //metni , lere ayırıp array'e attık 
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();  

        }
            
        protected override void OnBefore(IInvocation invocation) 
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
