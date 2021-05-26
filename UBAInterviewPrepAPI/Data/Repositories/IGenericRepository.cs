using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Data.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T GetById(Guid Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCount(int Count);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition);
        void Add(T entity);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
