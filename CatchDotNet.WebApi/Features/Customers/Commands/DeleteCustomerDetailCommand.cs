using FastEndpoints;
using ICommand = CatchDotNet.Core.Mediatr.Command.ICommand;

namespace CatchDotNet.WebApi;

public record DeleteCustomerDetailCommand : ICommand
{
    
    public Guid Id { get; init; }

    public string Key { get; init; }
}
