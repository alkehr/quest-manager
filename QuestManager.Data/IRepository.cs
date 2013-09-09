using System.Collections.Generic;

namespace QuestManager.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T Find(params object[] keyValues);
        void SaveChanges();
    }
}
