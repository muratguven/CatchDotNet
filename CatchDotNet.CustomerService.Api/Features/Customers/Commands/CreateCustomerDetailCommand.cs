using CatchDotNet.Core.Mediatr.Command;
using CatchDotNet.CustomerService.Api.Features.Customers.Dtos;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Commands
{
    public record CreateCustomerDetailCommand : ICommand
    {
        public Guid CustomerId { get; init; }
        
        public CustomerDetailInputDto CustomerDetail { get; init; }
    }
}
