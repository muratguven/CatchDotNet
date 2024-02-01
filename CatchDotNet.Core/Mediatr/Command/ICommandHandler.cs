using CatchDotNet.Core.Exceptions;
using MediatR;

namespace CatchDotNet.Core.Mediatr.Command;

public interface ICommandHandler<TCommand>: IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{

}

public interface ICommandHandler<TCommand,TResponse>: IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{

}
     