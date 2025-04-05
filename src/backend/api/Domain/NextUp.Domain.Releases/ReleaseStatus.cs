namespace NextUp.Domain.Releases;

/// <summary>
///     The status of a release.
/// </summary>
public enum ReleaseStatus
{
    /// <summary>
    ///     The release is being rumored.
    /// </summary>
    Rumor,

    /// <summary>
    ///     The release has been leaked.
    /// </summary>
    Leak,

    /// <summary>
    ///     The release was officially announced.
    /// </summary>
    Official,
}
