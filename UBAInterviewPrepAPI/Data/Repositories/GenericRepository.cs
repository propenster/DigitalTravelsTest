using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly MyDataContext Context;

        public GenericRepository(MyDataContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return Context.Set<T>().Where(condition).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetByCount(int Count)
        {
            return Context.Set<T>().Take(Count).ToList();
        }

        public T GetById(Guid Id)
        {
            return Context.Set<T>().Find(Id); //this will not work... I'm sure ..
        }
        

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
