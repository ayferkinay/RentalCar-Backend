using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        T GetById(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
    }
}
    