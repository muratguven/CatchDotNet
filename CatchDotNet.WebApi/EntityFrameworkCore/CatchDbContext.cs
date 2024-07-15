using CatchDotNet.WebApi.Features.Identity.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.WebApi
{
    public class CatchDbContext : IdentityDbContext<User>
    {
        public CatchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerDetail> CustomerDetail { get; set; }

        public DbSet<User> User { get; set; }

        

        const string identityScheme = "Identity";
        const string customerScheme = "Customer";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(b =>
            {

                b.ToTable(name:"Customers", customerScheme);
                b.HasKey(p => p.Id);

                b.Property(p => p.NameSurname).IsRequired();
                b.Property(p => p.Email).IsRequired();
                b.Property(p => p.PhoneNumber).IsRequired();
                b.Property(p => p.IsActive).IsRequired();
                b.HasMany(p => p.Details).WithOne(x => x.Customer).HasForeignKey(f => f.CustomerId);
                b.HasQueryFilter(c => c.IsDeleted == false);

            });

            modelBuilder.Entity<CustomerDetail>(b => {
                b.ToTable(name:"CustomerDetails",customerScheme);
                b.HasKey(p => p.Id);
                b.Property(p => p.CustomerId).IsRequired();
                b.Property(p => p.DetailKey).IsRequired();
                b.Property(p => p.DetailValue).IsRequired();
                b.HasQueryFilter(c => c.IsDeleted == false);
            });


            // Identity tables names 
            
            modelBuilder.Entity<User>(b => {
                b.ToTable(name: "Users", identityScheme);
            });
            modelBuilder.Entity<IdentityRole>(b => {
                b.ToTable(name: "Roles", identityScheme);
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b => {
                b.ToTable(name: "UserLogins", identityScheme);
              
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b => {
                b.ToTable(name: "UserClaims", identityScheme);
            
            });
            modelBuilder.Entity<IdentityUserToken<string>>(b => {
                b.ToTable(name: "UserTokens", identityScheme);
               
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b => {
                b.ToTable(name: "UserRoles", identityScheme);
            
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b => {
                b.ToTable(name: "RoleClaims", identityScheme);
              
            });

           
        }
    }
}
