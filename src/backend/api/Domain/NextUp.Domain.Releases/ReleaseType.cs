namespace NextUp.Domain.Releases;

/// <summary>
///     The type of release.
/// </summary>
public enum ReleaseType
{
    /// <summary>
    ///     The release is the release of a game.
    /// </summary>
    GameRelease,

    /// <summary>
    ///     The release is the release of additional content such as a DLC.
    /// </summary>
    AdditionalContent,

    /// <summary>
    ///     The release is a bigger update of a game. Such as the regular Minecraft updates.
    /// </summary>
    Update,
}
