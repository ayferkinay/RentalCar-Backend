using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.Id equals color.ColorId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 ColorId = car.ColorId,
                                 BrandId = car.BrandId,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
