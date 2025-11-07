namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     A release that has no date yet. To be announced.
/// </summary>
public sealed class NoReleaseDate : IReleaseDate
{
    /// <inheritdoc />
    public DateTimeOffset? GetDisplayDate()
    {
        return null;
    }
}
