using CatchDotNet.API.Infrastructure.Data;
using CatchDotNet.API.Infrastructure.EntityFrameworkCore;

namespace CatchDotNet.API.Domains
{
    public interface ICustomerRepository : IRepository<Customer>
    {

    }
}
