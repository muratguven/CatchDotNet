using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.CustomerService.Api.Features.Customers.Dtos;
using FastEndpoints;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Queries;

public record GetCustomerWithDetailQuery : IQuery<CustomerWithDetailDto>
{
    [FromBody]
    public Guid Id { get; init; }
}
