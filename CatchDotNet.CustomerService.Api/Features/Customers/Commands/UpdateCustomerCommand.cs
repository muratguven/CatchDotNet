using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.CustomerService.Api.Features.Customers.Commands;

public sealed record UpdateCustomerCommand
    (
        Guid id, 
        string nameSurname, 
        string email, 
        string phoneNumber, 
        bool isActive
    ):ICommand<Guid>;
