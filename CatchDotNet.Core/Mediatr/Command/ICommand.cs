using MediatR;

namespace CatchDotNet.Core.Mediatr.Command;

public interface ICommand : IRequest<Result>
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}

