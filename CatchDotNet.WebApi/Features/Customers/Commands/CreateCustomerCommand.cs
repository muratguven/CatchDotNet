

using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi;


public sealed  record CreateCustomerCommand(string NameSurname, string Email, string PhoneNumber, bool IsActive) : ICommand;
