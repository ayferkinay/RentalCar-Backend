using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IResult Add(IFormFile file , int carId);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);


        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetById(int id);

      

        // IFormFile : HttpRequest ile gönderilen bir dosyayı temsil eder.
    }
}
