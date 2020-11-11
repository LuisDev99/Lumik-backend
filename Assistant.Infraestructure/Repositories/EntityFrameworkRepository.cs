using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;

namespace Assistant.Infraestructure.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AssistantDbContext _dbContext;

        public EntityFrameworkRepository(AssistantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<T> Get()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Insert(int id, T data)
        {
            /**
             * TODO: Figure out how to change the base IService in order to get the object
             * to insert into the database
             */
            throw new NotImplementedException();
        }

        public T Update(int id, T data)
        {
            /**
             * TODO: Figure out how to change the base IService in order to get the object
             * to update into the database
             */
            throw new NotImplementedException();
        }

        public T Delete(int id)
        {
            /**
             * TODO: Figure out how to change the base IService in order to get the object
             * to delete into the database
             */
            throw new NotImplementedException();
        }
    }
}
