using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;


        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1, BrandId=2, ColorId=1, DailyPrice=2500, ModelYear=1990,Description="Yeni Kullanılmamış"},
                new Car{Id=2, BrandId=4, ColorId=1, DailyPrice=70, ModelYear=1990,Description="Yeni "},
                new Car{Id=3, BrandId=4, ColorId=2, DailyPrice=2000, ModelYear=1990,Description="Hasarlı"},
                new Car{Id=4, BrandId=3, ColorId=2, DailyPrice=1500, ModelYear=1990,Description="Boyalı"},
                new Car{Id=5, BrandId=1, ColorId=3, DailyPrice=200, ModelYear=1990,Description="Kış Zinciri Var"},
                new Car{Id=6, BrandId=2, ColorId=3, DailyPrice=1000, ModelYear=1990,Description="Kaza geçmişi var"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car removeCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(removeCar);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.Id = car.Id;
            updateCar.Description = car.Description;
            updateCar.BrandId = car.BrandId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.ColorId = car.ColorId;
            updateCar.ModelYear = car.ModelYear;
        }



        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetId(int id)
        {
            return  _cars.Where(c=>c.Id==id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
