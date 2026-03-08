using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using NextUp.Api.Games.GameDevelopers;

namespace NextUp.Api.Games;

public static class GamesEndpointsBuilder
{
    public static IEndpointRouteBuilder MapGamesEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGroup("/games")
            .MapGameDevelopersEndpoints();
        
        return builder;
    }
}
