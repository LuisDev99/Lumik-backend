using Assistant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Assistant.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository) 
        {
            _repository = repository;   
        }       

        public ServiceResult<T> Delete(T entity)
        {
            _repository.Delete(entity);

            return ServiceResult<T>.SuccessResult(entity);
        }

        public ServiceResult<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate)
        {
            return ServiceResult<IEnumerable<T>>.SuccessResult(_repository.Filter(predicate));
        }

        public ServiceResult<IEnumerable<T>> Get()
        {
            return ServiceResult<IEnumerable<T>>.SuccessResult(_repository.Get());            
        }

        public ServiceResult<T> GetByID(int id)
        {
            return ServiceResult<T>.SuccessResult(_repository.GetByID(id));
        }

        public ServiceResult<T> Insert(T entity)
        {
            return ServiceResult<T>.SuccessResult(_repository.Insert(entity));
        }

        public ServiceResult<T> Update(T entity)
        {
            return ServiceResult<T>.SuccessResult(entity);
        }
    }
}
