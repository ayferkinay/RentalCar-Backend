using Business.Abstract;
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

        public void Add(Rental rental)
        {
          
        }

        public void Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public Rental GetById(int rentalId)
        {
            return _rentalDal.Get(r => r.Id == rentalId);
        }

        public void Update(Rental rental)
        {
            _rentalDal.Update(rental);
        }
    }
}
