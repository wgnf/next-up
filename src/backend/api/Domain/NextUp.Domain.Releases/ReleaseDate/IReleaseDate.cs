namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     The date of a release.
/// </summary>
public interface IReleaseDate
{
    /// <summary>
    ///     The date that should be displayed. Can be inaccurate depending on the data provided.
    /// </summary>
    /// <returns>The date that should be displayed. Can be null.</returns>
    protected abstract DateTimeOffset? GetDisplayDate();
}
