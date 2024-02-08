using CatchDotNet.Core.Domain;
using System.Linq.Expressions;

namespace CatchDotNet.Core.Data;

public abstract class Repository<TEntity> : IRepository<TEntity>
{



    public abstract TEntity? Find(Expression<Func<TEntity, bool>> predicate);
    public abstract Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    public abstract IQueryable<TEntity> GetAll();

    public abstract List<TEntity> GetList();
    public abstract List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    public abstract Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);
    public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    public abstract void Insert(TEntity input);
    public abstract Task InsertAsync(TEntity input, CancellationToken cancellationToken = default);

    public abstract TEntity? Get(Guid id);

    public abstract Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    public abstract void Delete(Guid id);
    public abstract void Update(TEntity input);

    public abstract Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes);

    public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

    public abstract void HardDelete(Guid id);
}

public abstract class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>        
{
    public abstract TEntity? Get(TKey id);
    public abstract Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default);
   
    public abstract void Delete(TEntity input);

    public abstract void Delete(TKey id);

    public abstract void HardDelete(TKey id);
        
    
}