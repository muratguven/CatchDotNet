using CatchDotNet.API.Domains;
using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.Core.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.API.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContextBase<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, SoftDeleteInterceptor softDeleteInterceptor):base(options,softDeleteInterceptor)
        {
        }

        DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p=>p.Name).IsRequired();
                b.Property(p=>p.SurName).IsRequired();

            });
        }
    }
}
