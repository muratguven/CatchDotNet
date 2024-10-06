
using ICommand = CatchDotNet.Core.Mediatr.Command.ICommand;

namespace CatchDotNet.WebApi;

public record DeleteCustomerDetailCommand(Guid Id, string Key) : ICommand;
