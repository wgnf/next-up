namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     An approximate release date was announced, such as "in year 2025" or "in quarter 4 of 2026".
/// </summary>
public abstract class ApproximateReleaseDate : IReleaseDate
{
    /// <summary>
    ///     Gets the approximate release date of the given data.
    /// </summary>
    /// <returns>The approximate release date.</returns>
    protected abstract DateTimeOffset GetApproximateReleaseDate();

    /// <inheritdoc />
    public DateTimeOffset? GetDisplayDate()
    {
        return GetApproximateReleaseDate();
    }
}
