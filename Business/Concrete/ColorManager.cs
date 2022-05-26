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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.add")]
        [PerformanceAspect(5)]
        public IResult Add(Colorr Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.delete")]
        public IResult Delete(Colorr Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Colorr>> GetAll()
        {
            _colorDal.GetAll();
            return new SuccessDataResult<List<Colorr>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Colorr> GetById(int ColorId)
        {
           
            return new SuccessDataResult<Colorr>(_colorDal.GetById(c => c.ColorId == ColorId), Messages.ColorListed);
        }


        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.update")]
        [PerformanceAspect(5)]
        public IResult Update(Colorr Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
