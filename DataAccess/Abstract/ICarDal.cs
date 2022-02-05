using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public interface ICarDal
    {
        List<Car> GetAll();
        List<Car> GetId(int id);

        void Add(Car car);
        void Update(Car car);
        void Remove(Car car);
    }
}
