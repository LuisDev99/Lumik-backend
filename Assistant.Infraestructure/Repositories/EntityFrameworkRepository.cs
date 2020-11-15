using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<T> Get()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Insert(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Attach<T>(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();            
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}
