using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Colorr entity)
        {
            throw new NotImplementedException();
        }

        public Colorr Get(Expression<Func<Colorr, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Colorr> GetAll(Expression<Func<Colorr, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Colorr entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Colorr entity)
        {
            throw new NotImplementedException();
        }
    }
}
