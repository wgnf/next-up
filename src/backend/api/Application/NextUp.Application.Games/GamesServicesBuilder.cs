using Microsoft.Extensions.DependencyInjection;
using NextUp.Application.Abstractions;
using NextUp.Application.Games.GameDevelopers;
using NextUp.Domain.Games;

namespace NextUp.Application.Games;

public static class ApplicationGamesRegistration
{
    public static IServiceCollection RegisterGamesServices(this IServiceCollection services)
    {
        services.AddTransient<ICrudService<GameDeveloper>, GameDevelopersService>();

        return services;
    }
}
