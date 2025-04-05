namespace NextUp.Domain.Releases;

/// <summary>
///     A release that has no date yet. To be announced.
/// </summary>
public sealed class NoReleaseDate : ReleaseDate
{
    /// <inheritdoc />
    protected override DateTimeOffset? GetDisplayDate()
    {
        return null;
    }
}
