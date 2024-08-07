﻿using CatchDotNet.Core.Mediatr.Query;
using CatchDotNet.WebApi;
using FastEndpoints;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Queries;

public record GetCustomerWithDetailQuery : IQuery<CustomerWithDetailDto>
{
    [QueryParam, BindFrom("id")]
    public Guid Id { get; init; }
}
