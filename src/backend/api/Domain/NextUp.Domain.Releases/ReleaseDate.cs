namespace NextUp.Domain.Releases;

/// <summary>
///     The date of a release.
/// </summary>
public abstract class ReleaseDate
{
    /// <summary>
    ///     The date that should be displayed. Can be inaccurate depending.
    /// </summary>
    /// <returns>The date that should be displayed.</returns>
    protected abstract DateTimeOffset? GetDisplayDate();
}
