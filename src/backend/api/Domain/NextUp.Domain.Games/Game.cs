using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     A game.
///     I.e. Grand Theft Auto VI, Kingdom Come: Deliverance II, ...
/// </summary>
public sealed class Game
{
    public Game(
        string name,
        string description,
        GameDeveloper developer,
        GamePublisher publisher,
        IEnumerable<GamePlatform> platforms)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 3, 50);
        Name = name;

        Guard.Against.NullOrWhiteSpace(description);
        Guard.Against.LengthOutOfRange(description, 10, 1000);
        Description = description;

        Guard.Against.Null(developer);
        Developer = developer;

        Guard.Against.Null(Publisher);
        Publisher = publisher;

        var gamePlatforms = platforms.ToArray();
        Guard.Against.NullOrEmpty(gamePlatforms);
        Platforms = gamePlatforms;
    }

    /// <summary>
    ///     The name of the game.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     A description of the game.
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///     The developer of the game.
    /// </summary>
    public GameDeveloper Developer { get; }

    /// <summary>
    ///     The publisher of the game.
    /// </summary>
    public GamePublisher Publisher { get; }

    /// <summary>
    ///     The platforms the game was or will be released on.
    /// </summary>
    public IReadOnlyCollection<GamePlatform> Platforms { get; }
}
