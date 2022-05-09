using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            //validation yapıldığında standart kod
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context); //context buradaki entity nesnesinden gelen contextler yani productname vs 

            if (!result.IsValid) //validiton geçerli değilse hata verir
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
