using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Features.Cases.Commands;

public sealed record CreateCaseCommand
    (
        Guid CustomerId, 
        Guid CategoryId, 
        Guid StatusId, 
        string Title, 
        string Description) : ICommand;
