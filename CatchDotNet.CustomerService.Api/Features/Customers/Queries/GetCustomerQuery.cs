using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Dtos;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public record GetCustomerQuery : IQuery<List<CustomerDto>> 
    {
    }
}
