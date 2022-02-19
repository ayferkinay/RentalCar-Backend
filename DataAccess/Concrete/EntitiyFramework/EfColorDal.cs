using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        //public void Add(Colorr entity)
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();

        //    }
        //}

        //public void Remove(Colorr entity)
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public void Update(Colorr entity)
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}


        //public Colorr Get(Expression<Func<Colorr, bool>> filter)
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        return context.Set<Colorr>().SingleOrDefault(filter);
        //    }
        //}

        //public List<Colorr> GetAll(Expression<Func<Colorr, bool>> filter = null)
        //{
        //    using (CarContext context = new CarContext())
        //    {
        //        return filter == null ? context.Set<Colorr>().ToList() : context.Set<Colorr>().Where(filter).ToList();
        //    }
        //}
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
