using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     The studio that developed a game.
/// </summary>
/// <example>Rockstar, Warhorse Studios, ...</example>
public sealed class GameDeveloper : Entity
{
    public GameDeveloper(EntityId id, string name) : base(id)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 3, 50);

        Name = name;
    }

    /// <summary>
    ///     The name of the game developer.
    /// </summary>
    public string Name { get; }
}
