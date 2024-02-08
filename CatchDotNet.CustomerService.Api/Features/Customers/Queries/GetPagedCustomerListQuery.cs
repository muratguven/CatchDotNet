﻿using CatchDotNet.Core;
using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.Core.Pagination;
using FastEndpoints;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Queries
{
    public record GetPagedCustomerListQuery : IQuery<PagedResults<CustomerResponse>>
    {
        [QueryParam, BindFrom("currentPage")]
        public int CurrentPage { get; init; }
        //public int TotalPages { get; init; }
        [QueryParam,BindFrom("pageSize")]
        public int PageSize { get; init; }

        public int Skip
        {
            get
            {
                return (CurrentPage -1) * PageSize;
            }
        }
    }
}
