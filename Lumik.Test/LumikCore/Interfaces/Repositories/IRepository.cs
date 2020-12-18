using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T GetByID(int id);

        T GetByCondition(Expression<Func<T, bool>> predicate);

        T Insert(T entity);

        void Delete(T entity);

        void Update(T entity);                    

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
    }
}
