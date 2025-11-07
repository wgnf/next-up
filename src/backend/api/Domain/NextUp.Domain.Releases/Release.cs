using Ardalis.GuardClauses;
using NextUp.Domain.Games;
using NextUp.Domain.Releases.ReleaseDate;

namespace NextUp.Domain.Releases;

/// <summary>
///     A release of a game.
/// </summary>
public sealed class Release
{
    public Release(
        string title,
        IReleaseDate releaseDate,
        ReleaseType type,
        ReleaseStatus status,
        Game game,
        IEnumerable<GamePlatform> platforms,
        IEnumerable<ReleaseArticle> articles)
    {
        Guard.Against.NullOrWhiteSpace(title);
        Guard.Against.LengthOutOfRange(title, 5, 50);
        Title = title;

        Guard.Against.Null(releaseDate);
        ReleaseDate = releaseDate;

        Guard.Against.Null(type);
        Guard.Against.EnumOutOfRange(type);
        Type = type;

        Guard.Against.Null(status);
        Guard.Against.EnumOutOfRange(status);
        Status = status;

        Guard.Against.Null(game);
        Game = game;

        var releasePlatforms = platforms.ToArray();
        Guard.Against.NullOrEmpty(releasePlatforms);
        Platforms = releasePlatforms;

        var releaseArticles = articles.ToArray();
        Guard.Against.NullOrEmpty(releaseArticles);
        Articles = releaseArticles;
    }

    /// <summary>
    ///     The title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    ///     The release date.
    /// </summary>
    public IReleaseDate ReleaseDate { get; }

    /// <summary>
    ///     The type.
    /// </summary>
    public ReleaseType Type { get; }

    /// <summary>
    ///     The status.
    /// </summary>
    public ReleaseStatus Status { get; }

    /// <summary>
    ///     The associated game.
    /// </summary>
    public Game Game { get; }

    /// <summary>
    ///     The platforms the release is for.
    /// </summary>
    public IReadOnlyCollection<GamePlatform> Platforms { get; }

    /// <summary>
    ///     Articles associated with the release.
    /// </summary>
    public IReadOnlyCollection<ReleaseArticle> Articles { get; }
}
