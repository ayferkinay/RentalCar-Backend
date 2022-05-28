using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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




        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(c=>c.BrandId==brandId));
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(c => c.ColorId == colorId));
        }


        
        //[PerformanceAspect(5)]
        //[CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour==11)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintananceTime);
            //}

            //iş kodları
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(),Messages.CarListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _cardDal.GetCarDetails());
        }

        [PerformanceAspect(5)]
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarDescInvalid);
            }

            _cardDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")] // ICarService de bütün getleri sil
        public IResult Update(Car car)
        {
            _cardDal.Update(car);
            return new SuccessResult(Messages.CarUpdated); //success result zaten true olduğu için true olarak belirtmeye gerek yok  
            //return new SuccessResult(); bu şekilde de yazabilrdik. bu durumda parametresiz ctor çalışırdı ve message olmayacak şekilde true dönerdi
        }


        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.delete")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _cardDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


       
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_cardDal.GetById(x => x.Id == id), Messages.CarListed);
        }
    }
}
