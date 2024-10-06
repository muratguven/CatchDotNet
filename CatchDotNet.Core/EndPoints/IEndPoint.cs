using Microsoft.AspNetCore.Routing;

namespace CatchDotNet.Core.EndPoints;

public interface IEndPoint
{
    //Map to Endpoints
    void MapEndPoints(IEndpointRouteBuilder app);
}