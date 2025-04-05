using Ardalis.GuardClauses;

namespace NextUp.Domain.Releases;

/// <summary>
///     The exact release date has been announced.
/// </summary>
public sealed class ExactReleaseDate : ReleaseDate
{
    private readonly DateTimeOffset _exactReleaseDate;

    public ExactReleaseDate(DateTimeOffset exactReleaseDate)
    {
        Guard.Against.Null(exactReleaseDate);
        _exactReleaseDate = exactReleaseDate;
    }

    /// <inheritdoc />
    protected override DateTimeOffset? GetDisplayDate()
    {
        return _exactReleaseDate;
    }
}
