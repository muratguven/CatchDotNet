using Carter;
using CatchDotNet.Core.Exceptions;
using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
using FastEndpoints;
using MediatR;

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
        AllowAnonymous();
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


public class GetCustomerEndPoint : EndpointWithoutRequest<Result<List<CustomerResponse>>>
{
    private ISender _sender;

    public GetCustomerEndPoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("/api/customers");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken ct)
    {
        var req = new GetCustomerQuery();

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
