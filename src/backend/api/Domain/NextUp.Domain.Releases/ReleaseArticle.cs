using Ardalis.GuardClauses;

namespace NextUp.Domain.Releases;

/// <summary>
///     An article that mentions a release.
/// </summary>
public sealed class ReleaseArticle
{
    public ReleaseArticle(string title, string link)
    {
        Guard.Against.NullOrWhiteSpace(title);
        Guard.Against.LengthOutOfRange(title, 5, 50);
        Title = title;

        Guard.Against.NullOrWhiteSpace(link);
        Guard.Against.StringTooShort(link, 5);
        Link = link;
    }

    /// <summary>
    ///     The title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    ///     The link.
    /// </summary>
    public string Link { get; }
}
