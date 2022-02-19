using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{   
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {

        List<T> GetAll(Expression<Func<T,bool>>filter=null); //filtreleme yapabiliyoruz
        T Get(Expression<Func<T,bool>> filter);  //tek bir kayıtın detayını alır
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
