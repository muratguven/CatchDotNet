using MediatR;

namespace CatchDotNet.Core.Mediatr.Query;

public interface IQueryHandler<TQuery,TResponse>:IRequestHandler<TQuery,Result<TResponse>>
    where TQuery:IQuery<TResponse>
{
}
