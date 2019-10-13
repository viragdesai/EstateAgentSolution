using System;
using System.Collections.Generic;

namespace EstateAgentSolution.DataModel.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate);
        TEntity Get(Func<TEntity, bool> predicate);
        void Delete(Func<TEntity, bool> predicate);
        bool Exists(int key);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        TEntity GetFirst(Func<TEntity, bool> predicate);
        int Count();
    }
}
