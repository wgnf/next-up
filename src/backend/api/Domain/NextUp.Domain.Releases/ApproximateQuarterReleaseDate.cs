using Ardalis.GuardClauses;

namespace NextUp.Domain.Releases;

/// <summary>
///     The year and quarter of a release have been given.
/// </summary>
public sealed class ApproximateQuarterReleaseDate : ApproximateReleaseDate
{
    private readonly Quarter _quarterOfRelease;
    private readonly int _yearOfRelease;

    public ApproximateQuarterReleaseDate(Quarter quarterOfRelease, int yearOfRelease)
    {
        Guard.Against.Null(quarterOfRelease);
        Guard.Against.EnumOutOfRange(quarterOfRelease);
        _quarterOfRelease = quarterOfRelease;

        Guard.Against.Null(yearOfRelease);
        Guard.Against.OutOfRange(yearOfRelease, nameof(yearOfRelease), 2020, 3000);
        _yearOfRelease = yearOfRelease;
    }

    /// <inheritdoc />
    protected override DateTimeOffset GetApproximateReleaseDate()
    {
        var (dayOfRelease, monthOfRelease) = _quarterOfRelease switch
        {
            Quarter.Q1 => (31, 3),
            Quarter.Q2 => (30, 6),
            Quarter.Q3 => (30, 9),
            Quarter.Q4 => (31, 12),
            _ => throw new ArgumentOutOfRangeException($"Invalid quarter '{_quarterOfRelease}'"),
        };

        var approximateReleaseDate = new DateTimeOffset(_yearOfRelease, monthOfRelease, dayOfRelease, 23, 59, 59, TimeSpan.Zero);
        return approximateReleaseDate;
    }
}
