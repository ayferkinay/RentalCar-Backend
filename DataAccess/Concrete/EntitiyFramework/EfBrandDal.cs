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
    public class EfBrandDal : IBrandDal
    {

        public void Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }


        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

     
    }
    }

