﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.DAL.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition);
        void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}
