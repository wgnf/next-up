using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///      A game.
///     I.e. Grand Theft Auto VI, Kingdom Come: Deliverance II, ...
/// </summary>
public sealed class Game
{
    public Game(
        string name,
        string description,
        GameDeveloper developer,
        GamePublisher publisher)
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
    }

    public string Name { get; }

    public string Description { get; }

    public GameDeveloper Developer { get; }

    public GamePublisher Publisher { get; }
}
