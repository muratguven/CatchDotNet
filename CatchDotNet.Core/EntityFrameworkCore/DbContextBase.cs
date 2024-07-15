using CatchDotNet.Core.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.Core.EntityFrameworkCore;

public abstract class DbContextBase<TDbContext> : DbContext
  where TDbContext : DbContext
{
    private readonly SoftDeleteInterceptor _softDeleteInterceptor;
    public DbContextBase(DbContextOptions<TDbContext> options, SoftDeleteInterceptor softDeleteInterceptor):base(options)
    {
        _softDeleteInterceptor = softDeleteInterceptor;
    }
    /*
     Base domain DbSet buraya ekle :)
     */

    protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_softDeleteInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}


