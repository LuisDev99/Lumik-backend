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

        public ServiceResult<T> Delete(int id)
        {
            _repository.Delete(id);
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate)
        {
            _repository.Filter(predicate);
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<T>> Get()
        {
            _repository.Get();
            throw new NotImplementedException();
        }

        public ServiceResult<T> GetByID(int id)
        {
            _repository.GetById(id);
            throw new NotImplementedException();
        }

        public ServiceResult<T> Insert(int id, T data)
        {
            // TODO: Get data from body
            //_repository.Insert(data);
            throw new NotImplementedException();
        }

        public ServiceResult<T> Update(int id, T data)
        {
            // TODO: Get data from body
            //_repository.Update(newData);
            throw new NotImplementedException();
        }
    }
}
