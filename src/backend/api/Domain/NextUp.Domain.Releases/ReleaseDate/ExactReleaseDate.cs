using Ardalis.GuardClauses;

namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     The exact release date has been announced.
/// </summary>
public sealed class ExactReleaseDate : IReleaseDate
{
    private readonly DateTimeOffset _exactReleaseDate;

    public ExactReleaseDate(DateTimeOffset exactReleaseDate)
    {
        Guard.Against.Null(exactReleaseDate);
        _exactReleaseDate = exactReleaseDate;
    }

    /// <inheritdoc />
    public DateTimeOffset? GetDisplayDate()
    {
        return _exactReleaseDate;
    }
}
