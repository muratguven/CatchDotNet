using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Commands
{
    public record DeleteCustomerCommand : ICommand
    {
        public Guid Id { get; init; }


    }
}
