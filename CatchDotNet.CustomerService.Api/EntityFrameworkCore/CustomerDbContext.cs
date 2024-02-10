using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.Core.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerDbContext : DbContextBase<CustomerDbContext>
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, SoftDeleteInterceptor softDeleteInterceptor) : base(options, softDeleteInterceptor)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerDetail> CustomerDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(p => p.Id);
                
                b.Property(p => p.NameSurname).IsRequired();
                b.Property(p => p.Email).IsRequired();
                b.Property(p => p.PhoneNumber).IsRequired();
                b.Property(p => p.IsActive).IsRequired();
                b.HasMany(p => p.Details).WithOne(x => x.Customer).HasForeignKey(f => f.CustomerId);
                b.HasQueryFilter(c => c.IsDeleted == false);

            });

            modelBuilder.Entity<CustomerDetail>(b => {
                b.ToTable("CustomerDetails");
                b.HasKey(p => p.Id);
                b.Property(p=>p.CustomerId).IsRequired();
                b.Property(p=>p.DetailKey).IsRequired();
                b.Property(p=>p.DetailValue).IsRequired();
                b.HasQueryFilter(c=>c.IsDeleted == false);
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
