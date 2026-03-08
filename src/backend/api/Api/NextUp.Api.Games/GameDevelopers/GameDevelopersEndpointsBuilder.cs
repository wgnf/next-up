using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace NextUp.Api.Games.GameDevelopers;

internal static class GameDevelopersEndpointsBuilder
{
    public static IEndpointRouteBuilder MapGameDevelopersEndpoints(this IEndpointRouteBuilder builder)
    {
        var developersGroup = builder.MapGroup("/developers");
        
        developersGroup
            .MapGet("/", GetDevelopers)
            .Produces<GameDev[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        
        return builder;
    }

    private static GameDev[] GetDevelopers()
    {
        var devs = new[] { new GameDev("Hello"), new GameDev("World") };
        return devs;
    }
}

public record GameDev(string Name);
