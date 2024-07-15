using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.WebApi;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public record GetCustomersQuery : IQuery<List<CustomerDto>> 
    {
    }
}
