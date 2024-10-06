using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.WebApi.Features.Cases.Dtos;

namespace CatchDotNet.WebApi.Features.Cases.Queries;

public record GetCustomerCasesQuery : IQuery<List<CaseDto>>
{
    public Guid CustomerId { get; init; }
    
    public string? PhoneNumber { get; init; }
}
