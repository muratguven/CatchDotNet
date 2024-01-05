using CatchDotNet.API.Infrastructure.Domain;
using System.Linq.Expressions;

namespace CatchDotNet.API.Infrastructure.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
  where TEntity : class, IEntity
    {
        

        //public abstract Task DeleteAsync(TEntity input);
        public abstract TEntity Find(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract IQueryable<TEntity> GetAll();
        // public abstract Task<IQueryable<TEntity>> GetAllAsync();
        public abstract List<TEntity> GetList();
        public abstract List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<List<TEntity>> GetListAsync();
        public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        //public abstract Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes);
        //public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        public abstract void Insert(TEntity input);
        public abstract Task InsertAsync(TEntity input);
    }

    public abstract class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public abstract TEntity Get(TKey id);
        public abstract Task<TEntity> GetAsync(TKey id);
        public abstract void Update(TEntity input);
        public abstract void Delete(TEntity input);
    }
}
