﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(c=>c.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(c => c.ColorId == colorId));
        }


        [CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintananceTime);
            }

            //iş kodları
            return new SuccessDataResult<List<Car>>(_cardDal.GetAll(),Messages.CarListed);
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _cardDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {

            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarDescInvalid);
            }

            _cardDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")] // IPRoductService de bütün getleri sil
        public IResult Update(Car car)
        {
            _cardDal.Update(car);
            return new SuccessResult(Messages.CarUpdated); //success result zaten true olduğu için true olarak belirtmeye gerek yok  
            //return new SuccessResult(); bu şekilde de yazabilrdik. bu durumda parametresiz ctor çalışırdı ve message olmayacak şekilde true dönerdi
        }

        public IResult Delete(Car car)
        {
            _cardDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {

            Add(car);
            if (car.DailyPrice <0)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }
    }
}
