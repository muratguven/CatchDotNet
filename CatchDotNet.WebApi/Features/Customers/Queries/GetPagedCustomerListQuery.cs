using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.Core.Pagination;

namespace CatchDotNet.WebApi.Features.Customers.Queries;

public record GetPagedCustomerListQuery : IQuery<PagedResults<CustomerDto>>
{
    public GetPagedCustomerListQuery(int currentPage, int pageSize)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
    public int CurrentPage { get; init; }
    //public int TotalPages { get; init; }
    
    public int PageSize { get; init; }

    public int Skip
    {
        get
        {
            return (CurrentPage -1) * PageSize;
        }
    }
}
