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
            try
            {
                _repository.Delete(entity);

            } catch(Exception e)
            {
                return ServiceResult<T>.ErrorResult(e.Message);
            }

            return ServiceResult<T>.SuccessResult(entity);
        }

        public ServiceResult<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> filteredResults;

            try
            {
                filteredResults = _repository.Filter(predicate);

            } catch(Exception e)
            {
                return ServiceResult<IEnumerable<T>>.ErrorResult(e.Message);
            }

            return ServiceResult<IEnumerable<T>>.SuccessResult(filteredResults);
        }

        public ServiceResult<IEnumerable<T>> Get()
        {
            IEnumerable<T> results;

            try
            {
                results = _repository.Get();

            } catch(Exception e)
            {
                return ServiceResult<IEnumerable<T>>.ErrorResult(e.Message);
            }

            return ServiceResult<IEnumerable<T>>.SuccessResult(results);            
        }

        public ServiceResult<T> GetByID(int id)
        {
            T result;

            try
            {
                result = _repository.GetByID(id);

            } catch(Exception e)
            {
                return ServiceResult<T>.ErrorResult(e.Message);
            }

            if(result == null)
            {
                return ServiceResult<T>.NotFoundResult("Identidad no fue encontrada");
            }

            return ServiceResult<T>.SuccessResult(result);
        }

        public virtual ServiceResult<T> Insert(T entity)
        {
            T result;

            try
            {
                result = _repository.Insert(entity);

            } catch(Exception e)
            {
                return ServiceResult<T>.ErrorResult(e.Message);
            }

            return ServiceResult<T>.SuccessResult(result);
        }

        public ServiceResult<T> Update(T entity)
        {
            try
            {
                _repository.Update(entity);

            } catch(Exception e)
            {
                return ServiceResult<T>.ErrorResult(e.Message);
            }

            return ServiceResult<T>.SuccessResult(entity);
        }
    }
}
