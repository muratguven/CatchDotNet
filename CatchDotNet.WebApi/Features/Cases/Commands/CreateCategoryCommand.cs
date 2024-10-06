using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Features.Cases.Commands;

public sealed record CreateCategoryCommand(Guid? ParentId, string Name, bool IsActive) : ICommand;