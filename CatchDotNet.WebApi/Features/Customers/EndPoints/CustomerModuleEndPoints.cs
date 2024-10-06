using CatchDotNet.Core.EndPoints;
using CatchDotNet.CustomerService.Api.Features.Customers;
using CatchDotNet.WebApi.Commands;
using CatchDotNet.WebApi.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.WebApi.Features.Customers.EndPoints;

public static class CustomerTag
{
    public const string Customer = "Customer";
}


public class CreateCustomerEndPoint : IEndPoint
{
   
    
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapPost("api/customers", async ([FromServices]ISender _sender, CreateCustomerCommand customer, CancellationToken ct) =>
        {
            var result = await _sender.Send(customer, ct);
            if (result.IsFailure)
            {
                
                return Results.NotFound(result.Error);
            }

            return Results.Ok();
        }).WithTags(CustomerTag.Customer);
    }
}

public class GetCustomerEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/customers", async ([FromServices] ISender _sender,CancellationToken cancellationToken) =>
        {
            var results = await _sender.Send(new GetCustomersQuery(),cancellationToken);
           
            if (results is null)
            {
                return Results.NotFound();
            }

            if (results.IsFailure)
            {
                return Results.Problem(results.Error);
            }

            return Results.Ok(results.Value);
        }).WithTags(CustomerTag.Customer);

    }
}

public class UpdateCustomerEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapPut("api/customers/{id}",
            async ([FromServices] ISender _sender,
               [FromBody] UpdateCustomerCommand command,
                CancellationToken ct) =>
        {
            var result = await _sender.Send(command, ct);
            if (result.IsFailure)
            {
                return Results.NotFound(result.Error);
            }
            
            return Results.Ok(result);
        }).WithTags(CustomerTag.Customer);
    }
}

public class GetPagedCustomersEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapGet("api/customers/get-paged",
            async ([FromServices] ISender _sender,
                [FromBody]GetPagedCustomerListQuery query,
                CancellationToken cancellationToken) =>
        {
            var results = await _sender.Send(query, cancellationToken);
            if (results.IsFailure)
            {
                return Results.NotFound(results.Error);
            }
            return Results.Ok(results);
        }).WithTags(CustomerTag.Customer);
    }
}

public class DeleteCustomerEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/customers/{id}",
            async ([FromServices] ISender _sender, [FromBody]DeleteCustomerCommand command, CancellationToken ct) =>
            {
                var result = await _sender.Send(command, ct);
                if (result.IsFailure)
                {
                    return Results.NotFound(result.Error);
                }

                return Results.Ok();
            }).WithTags(CustomerTag.Customer);
    }
}

public class CreateCustomerDetailEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapPost("api/customers/detail",
            async ([FromServices] ISender _sender,
               [FromBody] CreateCustomerDetailCommand command,
                CancellationToken cancellationToken) =>
            {
                var result = await _sender.Send(command, cancellationToken);
                if (result.IsFailure)
                {
                    return Results.Problem(result.Error);
                }
                
                return Results.Ok(result);
            }).WithTags(CustomerTag.Customer);
    }
}

public class GetCustomerWithDetailEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapGet("api/customers/detail/{id}",
            async ([FromServices] ISender _sender,
                [FromQuery]Guid id,
                CancellationToken cancellationToken) =>
            {
                var query = new GetCustomerWithDetailQuery(id);
                
                var result = await _sender.Send(query, cancellationToken);
                if (result.IsFailure)
                {
                    return Results.NotFound(result.Error);
                }
                return Results.Ok(result);
            }).WithTags(CustomerTag.Customer);
    }
}

public class DeleteCustomerDetailEndPoint : IEndPoint
{
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/customers/detail",
            async ([FromServices] ISender _sender,
                [FromBody]DeleteCustomerDetailCommand command,
                CancellationToken cancellationToken) =>
            {
                var result = await _sender.Send(command, cancellationToken);
                if (result.IsFailure)
                {
                    return Results.Problem(result.Error);
                }
                return Results.Ok(result);
            }).WithTags(CustomerTag.Customer);
    }
}