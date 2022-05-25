using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.RentDate).NotEmpty().WithMessage("Rent date cannot be empty");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("Return date cannot be empty");
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car Id cannot be empty");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id cannot be empty");
        }
    }
}
