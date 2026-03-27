using NextUp.Api.Commons.Functional;
using NextUp.Application.Abstractions;
using NextUp.Domain;
using NextUp.Domain.Games;

namespace NextUp.Application.Games.GameDevelopers;

internal sealed class GameDevelopersService : ICrudService<GameDeveloper>
{
    public Task<IEnumerable<GameDeveloper>> GetAllAsync()
    {
        var devs = new[]
        {
            new GameDeveloper(EntityId.CreateNew(), "Hello"),
            new GameDeveloper(EntityId.CreateNew(), "World"),
        };
        return Task.FromResult<IEnumerable<GameDeveloper>>(devs);
    }

    public Task<Optional<GameDeveloper>> GetByIdAsync(EntityId id)
    {
        return Task.FromResult(Optional<GameDeveloper>.None());
    }
}
