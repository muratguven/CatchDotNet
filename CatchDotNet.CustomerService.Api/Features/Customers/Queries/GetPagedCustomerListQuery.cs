using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.Core.Pagination;
using FastEndpoints;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Queries
{
    public record GetPagedCustomerListQuery : IQuery<PagedResults<CustomerResponse>>
    {
        
        public int CurrentPage { get; init; }
        //public int TotalPages { get; init; }
        
        public int PageSize { get; init; }
    }
}
