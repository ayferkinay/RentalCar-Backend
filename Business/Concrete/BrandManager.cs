using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [SecuredOperation("brand.add")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

             return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("brand.delete")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandDeleted);
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.GetById(x => x.BrandId == brandId), ("işlem başarılı"));
        }


        [SecuredOperation("brand.update")]
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
