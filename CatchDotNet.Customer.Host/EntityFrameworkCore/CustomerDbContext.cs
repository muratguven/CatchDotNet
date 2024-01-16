using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.Core.EntityFrameworkCore.Interceptors;
using CatchDotNet.Customer.Host.Domain;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.Customer.Host.EntityFrameworkCore
{
    public class CustomerDbContext : DbContextBase<CustomerDbContext>
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, SoftDeleteInterceptor softDeleteInterceptor) : base(options, softDeleteInterceptor)
        {

        }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<CustomerDetail> CustomerDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.NameSurname).IsRequired();
                b.Property(p => p.Email).IsRequired();
                b.Property(p => p.PhoneNumber).IsRequired();
                b.Property(p => p.IsActive).IsRequired();
                b.HasMany(p => p.Details).WithOne(x => x.Customer).HasForeignKey(f => f.CustomerId);

            });

            modelBuilder.Entity<CustomerDetail>(b => {
                b.ToTable("CustomerDetails");
                b.HasKey(p => p.Id);
                b.Property(p=>p.CustomerId).IsRequired();
                b.Property(p=>p.DetailKey).IsRequired();
                b.Property(p=>p.DetailValue).IsRequired();
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
