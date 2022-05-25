using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Colorr>
    {
        public ColorValidator()
        {
            RuleFor(c=>c.ColorName).MinimumLength(3);
            RuleFor(c=>c.ColorName).NotEmpty();
        }
    }
}
