using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi;

public sealed record UpdateCustomerCommand
    (
        Guid id, 
        string nameSurname, 
        string email, 
        string phoneNumber, 
        bool isActive
    ):ICommand<Guid>;
