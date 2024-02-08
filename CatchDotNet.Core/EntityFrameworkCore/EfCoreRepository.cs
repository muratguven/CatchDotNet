using CatchDotNet.Core.Data;
using CatchDotNet.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public abstract class EfCoreRepository<TDbContext, TEntity> : Repository<TEntity>, IEfCoreRepository<TEntity>
           where TDbContext : DbContext
           where TEntity :Entity
    {
        protected IDbContextProvider<TDbContext> DbContextProvider;
         
       
        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
           
           
            DbContextProvider = dbContextProvider;
        }

        protected DbContext DbContext => DbContextProvider.GetDbContext();

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();


        #region Commands
        public override void Insert(TEntity input)
        {
            DbSet.Add(input);
        }

        public override async Task InsertAsync(TEntity input,CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(input,cancellationToken);
        }

        public override void Update(TEntity input)
        {
            DbSet.Update(input);
        }

        public override void Delete(Guid id)
        {
            var data = DbSet.Where(x => x.Id == id).FirstOrDefault();
            if(data is not null)
            {
                Type entityType = data.GetType();
                var property = entityType.GetProperty("IsDeleted");
                if (property is not null)
                {
                    property.SetValue(data, true);
                }

                DbSet.Update(data);
            }
          
        }

        public override void HardDelete(Guid id)
        {
            var data = DbSet.Where(x => x.Id == id).FirstOrDefault();
            if(data is not null)
            DbSet.Remove(data);
        }
        #endregion


        #region Queries
        public override TEntity? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public override Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public override IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable<TEntity>();
        }


        public override List<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public override List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public override Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken=default)
        {
            return DbSet.ToListAsync(cancellationToken);
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.Where(predicate).ToListAsync(cancellationToken);
        }
        public override Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToListAsync();
        }
        public override async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }



        public override TEntity? Get(Guid id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }

        public override Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return DbSet.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        }

        #endregion


    }


    public abstract class EfCoreRepository<TDbContext, TEntity, TKey> : Repository<TEntity,TKey>,
        IEfCoreRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : Entity<TKey>
        where TKey : class
    {
        protected IDbContextProvider<TDbContext> DbContextProvider;


        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {

            DbContextProvider = dbContextProvider;
        }

        protected DbContext DbContext => DbContextProvider.GetDbContext();

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();


        #region Commands
        public override void Insert(TEntity input)
        {
            DbSet.Add(input);
        }

        public override async Task InsertAsync(TEntity input, CancellationToken cancellationToken=default)
        {
            await DbSet.AddAsync(input, cancellationToken);
        }
        public override void Update(TEntity input)
        {
            DbSet.Update(input);
        }

        public override void Delete(TEntity input)
        {
           
            Type entityType = typeof(TEntity);
            var property = entityType.GetProperty("IsDeleted");
            if (property is not null)
            {
                property.SetValue(input, true);
            }

            DbSet.Update(input);
        }

        public override void Delete(TKey id)
        {
            var data = DbSet.FirstOrDefault(x => x.Id == id);
            if (data is not null)
            {
                Type entityType = typeof(TEntity);
                var property = entityType.GetProperty("IsDeleted");
                if (property is not null)
                {
                    property.SetValue(data, true);
                    DbSet.Update(data);
                }
            }
            
        }

        public override void HardDelete(TKey id)
        {
            var data = DbSet.FirstOrDefault(x => x.Id == id);
            if(data is not null)
            DbSet.Remove(data);
        }
        #endregion


        #region Queries
        public override TEntity? Get(TKey id)
        {
            return DbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public override Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }



        public override Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToListAsync();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate).ToListAsync();
        }



        public override IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable<TEntity>();
        }

        public override TEntity? Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public override Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken=default)
        {
            return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public override List<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public override List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public override Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return DbSet.ToListAsync(cancellationToken);
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken=default)
        {
            return DbSet.Where(predicate).ToListAsync(cancellationToken);
        }

       

        #endregion


    }
}
