using CatchDotNet.Core.Mediatr.Command;

namespace CatchDotNet.WebApi.Features.Cases.Commands;

public sealed record DeleteCaseCommand(Guid Id):ICommand;
