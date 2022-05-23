using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
  public static  class ServiceCollectionsExtensions
    {                                                           //this ile neyi genişletmek istiyorsak onu veriyoruz    

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}


//IServiceCollection : apimizin service bağımlılıklarını eklyeblidğimiz ya da araya girmesini istediiğimizi servicler için kullanırız