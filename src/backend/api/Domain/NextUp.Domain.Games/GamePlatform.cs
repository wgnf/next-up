using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     The platform a game can be published on.
/// </summary>
/// <example>Playstation 5, Xbox Series X, Switch 2, Steam, Epic Games, ...</example>
public sealed class GamePlatform
{
    public GamePlatform(string name)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 3, 50);

        Name = name;
    }

    /// <summary>
    ///     The name of the game platform.
    /// </summary>
    public string Name { get; }
}
