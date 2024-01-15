using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public abstract class DbContextBase<TDbContext> : DbContext
      where TDbContext : DbContext
    {
        public DbContextBase(DbContextOptions<TDbContext> options):base(options)
        {
            
        }
        /*
         Base domain DbSet buraya ekle :)
         */

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
