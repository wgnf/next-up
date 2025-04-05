using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     The studio that developed a game.
///     I.e. Rockstar, Warhorse Studios, ...
/// </summary>
public sealed class GameDeveloper
{
    public GameDeveloper(string name)
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
