using CatchDotNet.Core.Exceptions;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using MediatR;

namespace CatchDotNet.CustomerService.Api.Features.Customers
{
    public record GetCustomerQuery : IQuery<List<CustomerResponse>> 
    {
    }
}
