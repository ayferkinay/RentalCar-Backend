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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Colorr Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Colorr Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Colorr>> GetAll()
        {
            _colorDal.GetAll();
            return new SuccessDataResult<List<Colorr>>(Messages.ColorListed);
        }

        public IDataResult<Colorr> GetById(int ColorId)
        {
            _colorDal.Get(c=> c.ColorId == ColorId);
            return new SuccessDataResult<Colorr>(Messages.ColorIsInvalid);
        }

        public IResult Update(Colorr Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
