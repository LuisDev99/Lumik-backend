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

        public ServiceResult<T> GetByCondition(Expression<Func<T, bool>> predicate);

        public ServiceResult<T> Insert(T entity);        

        public ServiceResult<T> Delete(T entity);

        public ServiceResult<T> Update(T entity);

        public ServiceResult<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate);
    }
}
