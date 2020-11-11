using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);

        T Insert(int id, T data);

        T Update(int id, T data);
            
        T Delete(int id);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);
    }
}
