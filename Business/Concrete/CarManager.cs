using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
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
        //private EfBrandDal efBrandDal;
        //private EfColorDal efColorDal;
            

        public CarManager(ICarDal carDal)
        {
            _cardDal = carDal;
        }
        //public CarManager(EfColorDal efColorDal)
        //{
        //    this.efColorDal = efColorDal;
        //}
        //public CarManager(EfBrandDal efBrandDal)
        //{
        //    this.efBrandDal = efBrandDal;
        //}

        public List<Car> GetByBrandId(int brandId)
        {
            return _cardDal.GetAll(c=>c.BrandId==brandId);
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _cardDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetAll()
        {
            //iş kodları
            return _cardDal.GetAll();
        }

      
    }
}
