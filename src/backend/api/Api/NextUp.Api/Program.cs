using System.Text.Json.Serialization;
using NextUp.Api.Games;
using NextUp.Api.Releases;

namespace NextUp.Api;

/*
 * TODO:
 * - Health Checks
 * - global.json
 */

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Add(AppJsonSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Add(GamesJsonContext.Default);
        });

        var app = builder.Build();
        var apiGroupBuilder = app.MapGroup("/api");

        apiGroupBuilder
            .MapGamesEndpoints()
            .MapReleasesEndpoints();

        var sampleTodos = new Todo[]
        {
            new(1, "Walk the dog"), new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)), new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            new(4, "Clean the bathroom"), new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
        };

        var todosApi = apiGroupBuilder.MapGroup("/todos");
        todosApi.MapGet("/", () => sampleTodos);
        todosApi.MapGet("/{id:int}", (int id) =>
            sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                ? Results.Ok(todo)
                : Results.NotFound());

        app.Lifetime.ApplicationStarted.Register(() => LogEndpoints(app));

        app.Run();
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

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;
