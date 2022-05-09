using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //if (rental.ReturnDate== null)
            //{
            //    return new ErrorResult(Messages.RentAdded);
            //}
            //return new SuccessResult(Messages.RentIsInvalid);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(Messages.RentListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            _rentalDal.Get(r=> r.Id==rentalId);
            return new SuccessDataResult<Rental>(Messages.RentIsInvalid);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.rentUpdated);
        }
    }
}
