using CatchDotNet.Core.Data;
using CatchDotNet.Core.Domain;
using System.Linq.Expressions;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity>
    {

    }


    public interface IEfCoreRepository<TEntity, TKey> : IEfCoreRepository<TEntity>, IRepository<TEntity, TKey>
    {

    }
}
