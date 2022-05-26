using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        IFileHelper _fileHelper; 
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carImage.add")]
        [PerformanceAspect(5)]
        public IResult Add(IFormFile file, int carId)
        {
        
            string imagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            _carImageDal.Add(new CarImage { CarId = carId, ImagePath = imagePath });
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
             var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carImage.delete")]
        [ValidationAspect(typeof(CarImageValidator))]
        [PerformanceAspect(5)]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Resim Başarıyla silindi");
        }


        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data); //eğer arabaya ait görüntülenecek image yoksa default olanı gösteirr

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                ImagePath = "DefaultImage.jpg"
            });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }


        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(c=>c.ID ==id));
        }


        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carImage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + carImage.ImagePath,PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult("resim başarıyla güncellendi");
        }

     
    }
}
