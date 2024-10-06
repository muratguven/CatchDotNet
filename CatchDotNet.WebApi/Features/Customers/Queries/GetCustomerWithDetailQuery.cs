using CatchDotNet.Core.Mediatr.Query;

namespace CatchDotNet.WebApi.Features.Customers.Queries;

public record GetCustomerWithDetailQuery(Guid Id) : IQuery<CustomerWithDetailDto>;

