using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QuestManager.Data
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public EntityFrameworkRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Remove(entity);
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
    }
}