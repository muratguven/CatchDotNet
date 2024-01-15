using CatchDotNet.Core.Data;
using CatchDotNet.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public abstract class EfCoreRepository<TDbContext, TEntity> : Repository<TEntity>, IEfCoreRepository<TEntity>
           where TDbContext : DbContext
           where TEntity : class, IEntity
    {
        protected IDbContextProvider<TDbContext> DbContextProvider;
         
       
        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
           
           
            DbContextProvider = dbContextProvider;
        }

        protected DbContext DbContext => DbContextProvider.GetDbContext();

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();



        public override TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public override Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
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

        public override Task<List<TEntity>> GetListAsync()
        {
            return DbSet.ToListAsync();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToListAsync();
        }
        public Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToListAsync();
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }
        public override void Insert(TEntity input)
        {
            DbSet.Add(input);
        }

        public override async Task InsertAsync(TEntity input)
        {
            await DbSet.AddAsync(input);
        }


    }


    public abstract class EfCoreRepository<TDbContext, TEntity, TKey> : EfCoreRepository<TDbContext, TEntity>,
        IEfCoreRepository<TEntity, TKey>
         where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        public EfCoreRepository(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {
            DbContextProvider = dbContextProvider;
            
        }

        public TEntity Get(TKey id)
        {
            return DbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(TEntity input)
        {
            DbSet.Update(input);
        }

        public void Delete(TEntity input)
        {
            DbSet.Remove(input);
        }

    }
}
