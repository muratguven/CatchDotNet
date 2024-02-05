using MediatR;

namespace CatchDotNet.Core.Mediatr.Query;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}


