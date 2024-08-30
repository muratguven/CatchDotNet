using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Features.Cases.Commands;

public sealed record DeleteCategoryCommand
    (
        Guid Id) : ICommand;