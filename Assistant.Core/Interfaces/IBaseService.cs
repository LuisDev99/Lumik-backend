using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IBaseService<T> 
    {
        //Declare all the CRUD operations that will exists for every entity service

        public ServiceResult<IEnumerable<T>> Get();

        public ServiceResult<T> GetByID(int id);

        public ServiceResult<T> Insert(int id, T data);

        public ServiceResult<T> Update(int id, T data);

        public ServiceResult<T> Delete(int id);

        public ServiceResult<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate);
    }
}
