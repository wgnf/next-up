using Ardalis.GuardClauses;

namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     The year of a release has been given.
/// </summary>
public sealed class ApproximateYearReleaseDate : ApproximateReleaseDate
{
    private readonly int _yearOfRelease;

    public ApproximateYearReleaseDate(int yearOfRelease)
    {
        Guard.Against.Null(yearOfRelease);
        Guard.Against.OutOfRange(yearOfRelease, nameof(yearOfRelease), 2020, 3000);

        _yearOfRelease = yearOfRelease;
    }

    /// <inheritdoc />
    protected override DateTimeOffset GetApproximateReleaseDate()
    {
        var approximateReleaseDate = new DateTimeOffset(_yearOfRelease, 12, 31, 23, 59, 59, TimeSpan.Zero);
        return approximateReleaseDate;
    }
}
