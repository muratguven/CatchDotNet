using CatchDotNet.Core.EndPoints;
using CatchDotNet.WebApi.Features.Cases.Commands;
using MediatR;

namespace CatchDotNet.WebApi.Features.Cases.EndPoints;

public class CreateCategoryEndPoint : IEndPoint
{
    private ISender _sender;

    public CreateCategoryEndPoint(ISender sender)
    {
        _sender = sender;
    }
    
    public void MapEndPoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/categories", async (CreateCategoryCommand category, CancellationToken ct) =>
        {
            var result = await _sender.Send(category, ct);
                        
            if (result.IsFailure)
                return Results.Problem(result.Error);
            else
                return Results.Ok();
        });
    }
}