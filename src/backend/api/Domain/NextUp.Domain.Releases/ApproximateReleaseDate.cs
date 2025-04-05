namespace NextUp.Domain.Releases;

/// <summary>
///     An approximate release date was announced, such as "in year 2025" or "in quarter 4 of 2026".
/// </summary>
public abstract class ApproximateReleaseDate : ReleaseDate
{
    /// <summary>
    ///     Gets the approximate release date of the given data.
    /// </summary>
    /// <returns>The approximate release date.</returns>
    protected abstract DateTimeOffset GetApproximateReleaseDate();

    /// <inheritdoc />
    protected override DateTimeOffset? GetDisplayDate()
    {
        return GetApproximateReleaseDate();
    }
}
