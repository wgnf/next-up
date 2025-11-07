using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     The company that published a game.
/// </summary>
/// <example>Rockstar, Sony Entertainment</example>
public sealed class GamePublisher
{
    public GamePublisher(string name)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 3, 50);

        Name = name;
    }

    /// <summary>
    ///     The name of the game publisher.
    /// </summary>
    public string Name { get; }
}
