using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using NextUp.Application.Abstractions;
using NextUp.Domain.Games;

namespace NextUp.Api.Games.GameDevelopers;

internal static class GameDevelopersEndpointsBuilder
{
    public static IEndpointRouteBuilder MapGameDevelopersEndpoints(this IEndpointRouteBuilder builder)
    {
        var developersGroup = builder.MapGroup("/devs");

        developersGroup
            .MapGet("/", async (ICrudService<GameDeveloper> service) => await service.GetAllAsync())
            .Produces<GameDeveloper[]>()
            .Produces(StatusCodes.Status400BadRequest);

        return builder;
    }
}
