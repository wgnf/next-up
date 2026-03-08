using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace NextUp.Api.Releases;

public static class ReleasesEndpointsBuilder
{
    public static IEndpointRouteBuilder MapReleasesEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGroup("/releases");
        
        return builder;
    }
}
