using CatchDotNet.API.Infrastructure.Data;
using CatchDotNet.API.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatchDotNet.API.Infrastructure.EntityFrameworkCore
{
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity>
      where TEntity : class, IEntity
    {
  
        DbContext DbContext { get; }
        DbSet<TEntity> DbSet { get; }

        /// <summary>
        /// Get all list with includes
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// Get all list with includes
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    }


    public interface IEfCoreRepository<TEntity, TKey> : IEfCoreRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}
