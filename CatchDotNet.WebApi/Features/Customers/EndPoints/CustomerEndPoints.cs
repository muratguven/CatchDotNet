// using CatchDotNet.Core;
// using CatchDotNet.Core.Pagination;
// using CatchDotNet.CustomerService.Api.Features.Customers.Queries;
// using CatchDotNet.WebApi;
// using CatchDotNet.WebApi.Commands;
// using FastEndpoints;
// using MediatR;
// using Microsoft.AspNetCore.Identity;
//
// namespace CatchDotNet.CustomerService.Api.Features.Customers;
//
//
//

//
//

//
//
//
//
//
//
//

//
//
// 
//
//
//
// public class DeleteCustomerDetailEndPoint: Endpoint<DeleteCustomerDetailCommand, Result>
// {
//     private readonly ISender _sender;
//
//     public DeleteCustomerDetailEndPoint(ISender sender)
//     {
//         _sender = sender;
//     }
//
//     public override void Configure()
//     {
//         Delete("api/customers/detail");
//         AllowAnonymous();
//     }
//
//     public override async Task HandleAsync(DeleteCustomerDetailCommand req, CancellationToken ct)
//     {
//         
//         var result = await _sender.Send(req, ct);
//
//         if (result is null)
//         {
//             await SendNotFoundAsync(ct);
//         }
//
//         if (result.IsFailure)
//         {
//             await SendErrorsAsync(StatusCodes.Status500InternalServerError,ct);
//         }
//
//         await SendOkAsync(result);
//
//     }
// }