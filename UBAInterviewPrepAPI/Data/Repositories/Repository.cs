using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    Context.Set<TEntity>().Add(entities);
        //}

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition)
        {
            return Context.Set<TEntity>().Where(condition);
        }

        public TEntity Get(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
