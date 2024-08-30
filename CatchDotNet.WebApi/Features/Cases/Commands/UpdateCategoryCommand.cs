using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Features.Cases.Commands;

public sealed record UpdateCategoryCommand
    (
        Guid Id, Guid? ParentId, string Name, bool IsActive) : ICommand<Guid>;