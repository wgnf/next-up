using NextUp.Api.Games;
using NextUp.Api.Releases;
using NextUp.Application.Games;

namespace NextUp.Api;

/*
 * TODO:
 * - Health Checks
 * - global.json
 * - API Versionierung?!
 * - User management
 */

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Add(GamesJsonContext.Default);
        });
        
        RegisterServices(builder.Services);

        var app = builder.Build();
        var apiGroupBuilder = app.MapGroup("/api");

        apiGroupBuilder
            .MapGamesEndpoints()
            .MapReleasesEndpoints();

        app.Lifetime.ApplicationStarted.Register(() => LogEndpoints(app));

        app.Run();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services
            .RegisterGamesServices();
    }

    private static void LogEndpoints(WebApplication app)
    {
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("Program");

        var endpoints = app
            .Services
            .GetRequiredService<IEnumerable<EndpointDataSource>>()
            .SelectMany(endpointDataSource => endpointDataSource.Endpoints)
            .OfType<RouteEndpoint>();

        var endpointsText = string.Join(Environment.NewLine, endpoints.Select(endpoint => $"\t> {endpoint.DisplayName}"));
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug("all registered endpoints:{NewLine}{RegisteredEndpointsText}", Environment.NewLine, endpointsText);
        }
    }
}
