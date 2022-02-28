using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;
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

        public List<CarDetailDto> GetCarDetails()
        {
            return _cardDal.GetCarDetails();
        }

        public IResult Add(Car car)
        {

            if (car.Description.Length<2)
            {
                return new ErrorResult("Ürün açıklaması yeterli değil");
            }

            _cardDal.Add(car);

            return new Result(true,"Ürün Eklendi");
        }

        public IResult Update(Car car)
        {
            _cardDal.Update(car);
            return new SuccessResult("Ürün Güncellendi"); //success result zaten true olduğu için true olarak belirtmeye gerek yok 
            //return new SuccessResult(); bu şekilde de yazabilrdik. bu durumda parametresiz ctor çalışırdı ve message olmayacak şekilde true dönerdi
        }

        public IResult Delete(Car car)
        {
            _cardDal.Delete(car);
            return new SuccessResult("Ürün Silindi");
        }
    }
}
