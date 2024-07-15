using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi;

public record CreateCustomerDetailCommand : ICommand
{
    public Guid CustomerId { get; init; }
    
    public CustomerDetailInputDto CustomerDetail { get; init; }
}
