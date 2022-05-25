using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
           
            RuleFor(x => x.DailyPrice).NotEmpty();
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.ModelYear).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Description should to be the least 10 character"); ;
            RuleFor(c => c.Description).MaximumLength(500);
        }
    }
}
