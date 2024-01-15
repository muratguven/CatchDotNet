using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public class AppDesignTimeDbContextFactory<TDbContext> :IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
    {


        public TDbContext CreateDbContext(string[] args)
        {



            throw new NotImplementedException();
        }
    }
}
