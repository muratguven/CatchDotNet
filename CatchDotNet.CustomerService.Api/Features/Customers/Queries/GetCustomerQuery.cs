using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public record GetCustomerQuery : IQuery<List<CustomerResponse>> 
    {
    }
}
