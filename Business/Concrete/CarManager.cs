using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardDal;
        public CarManager(ICarDal carDal)
        {
            _cardDal = carDal;
        }


        public List<Car> GetCars()
        {
            //iş kodları
            return _cardDal.GetAll();
        }

      
    }
}
