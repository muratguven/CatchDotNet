﻿using CatchDotNet.Core;
using CatchDotNet.Core.Pagination;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using CatchDotNet.WebApi;
using CatchDotNet.WebApi.Commands;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CatchDotNet.CustomerService.Api.Features.Customers;



public class CreateCustomerEndPoint : Endpoint<CreateCustomerCommand, Result>
{
    private ISender _sender;

    public CreateCustomerEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("/api/customers");
        AuthSchemes(IdentityConstants.BearerScheme);
    }

    public override async Task HandleAsync(CreateCustomerCommand req, CancellationToken ct)
    {
        var result = await _sender.Send(req);
        if (result.IsFailure)
        {
             await SendNotFoundAsync(ct);

        }

        await SendOkAsync(result);
       
    }

}


public class GetCustomerEndPoint : EndpointWithoutRequest<Result<List<CustomerDto>>>
{
    private ISender _sender;

    public GetCustomerEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("/api/customers");
        AuthSchemes(IdentityConstants.BearerScheme);
    }


    public override async Task HandleAsync(CancellationToken ct)
    {
        var req = new GetCustomersQuery();

        var result = await _sender.Send(req);

        if(result is null)
        {
            await SendNotFoundAsync(ct);
        }

        if (result.IsFailure)
        {
            await SendErrorsAsync(400, ct);
        }
      
           await SendOkAsync(result);
             
        
    }

}


public class UpdateCustomerEndPoint: Endpoint<UpdateCustomerCommand, Result<Guid>>
{
    private readonly ISender _sender;

    public UpdateCustomerEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Put("api/customers/{id}");
        AllowAnonymous();
    }


    public override async Task HandleAsync(UpdateCustomerCommand req, CancellationToken ct)
    {
        var result = await _sender.Send(req, ct);

        if(result is null)
        {
            await SendNotFoundAsync(ct);
        }
        if (result.IsFailure) { 
            await SendAsync(result,500,ct);
        }

        await SendOkAsync(result);

    }
}


public class GetPagedCustomersEndPoint : Endpoint<GetPagedCustomerListQuery, Result<PagedResults<CustomerDto>>>
{
    private ISender _sender;

    public GetPagedCustomersEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("/api/customers/get-paged");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPagedCustomerListQuery req, CancellationToken ct)
    {


        var result = await _sender.Send(req);
        if(result is null)
        {
            await SendNotFoundAsync(ct);
        }


        await SendOkAsync(result);
    }
}

public class DeleteCustomerEndPoint: Endpoint<DeleteCustomerCommand>
{
    private readonly ISender _sender;

    public DeleteCustomerEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure() 
    {
        Delete("api/customers/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCustomerCommand req, CancellationToken ct)
    {
       var result = await _sender.Send(req);
        if( result is null)
        {
            await SendNotFoundAsync(ct);
        }
        await SendOkAsync(result);
        
    }
}


public class CreateCustomerDetailEndPoint : Endpoint<CreateCustomerDetailCommand>
{

    private readonly ISender _sender;

    public CreateCustomerDetailEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Post("api/customers/detail");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCustomerDetailCommand req, CancellationToken ct)
    {
        var result = await _sender.Send(req);

        if(result is null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendOkAsync(result);


    }
}

public class GetCustomerWithDetailEndPoint: Endpoint<GetCustomerWithDetailQuery, Result<CustomerWithDetailDto>>
{
    private readonly ISender _sender;

    public GetCustomerWithDetailEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("api/customers/detail");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCustomerWithDetailQuery req, CancellationToken ct)
    {
       
        var result = await _sender.Send(req, ct);

        if(result is null)
        {
            await SendNotFoundAsync(ct);
        }

        if (result.IsFailure)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }

        await SendOkAsync(result);
    }
}


public class DeleteCustomerDetailEndPoint: Endpoint<DeleteCustomerDetailCommand, Result>
{
    private readonly ISender _sender;

    public DeleteCustomerDetailEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Delete("api/customers/detail");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCustomerDetailCommand req, CancellationToken ct)
    {
        
        var result = await _sender.Send(req, ct);

        if (result is null)
        {
            await SendNotFoundAsync(ct);
        }

        if (result.IsFailure)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError,ct);
        }

        await SendOkAsync(result);

    }
}