using FastEndpoints;
using ICommand = CatchDotNet.Core.Mediatr.Command.ICommand;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Commands;

public record DeleteCustomerDetailCommand : ICommand
{
    
    public Guid Id { get; init; }

    public string Key { get; init; }
}
