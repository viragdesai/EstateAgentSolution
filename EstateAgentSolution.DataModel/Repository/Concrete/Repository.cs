using EstateAgentSolution.DataModel.Context;
using EstateAgentSolution.DataModel.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgentSolution.DataModel.Repository.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _dbContext { get; set; }
        internal DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet;
            return await query.ToListAsync();
        }

        public virtual TEntity GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entity)
        {
            foreach (var item in entity)
            {
                _dbSet.Attach(item);
                _dbContext.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault<TEntity>();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            IQueryable<TEntity> objects = _dbSet.Where<TEntity>(predicate).AsQueryable();
            foreach (TEntity obj in objects)
                _dbSet.Remove(obj);
        }

        public bool Exists(int key)
        {
            return _dbSet.Find(key) != null;
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return _dbSet.Single<TEntity>(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _dbSet.First<TEntity>(predicate);
        }
        public int Count()
        {
            return _dbSet.Count();
        }
    }
}
