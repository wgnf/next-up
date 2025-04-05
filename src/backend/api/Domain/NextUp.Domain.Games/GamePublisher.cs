using Ardalis.GuardClauses;

namespace NextUp.Domain.Games;

/// <summary>
///     The company that published a game.
///     I.e. Rockstar, Sony Entertainment, ...
/// </summary>
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
