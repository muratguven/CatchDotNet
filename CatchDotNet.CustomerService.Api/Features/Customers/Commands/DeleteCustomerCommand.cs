using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Commands
{
    public record DeleteCustomerCommand : ICommand
    {
        public Guid Id { get; init; }


    }
}
