using NextUp.Api.Commons.Functional;

namespace NextUp.Domain.Releases.ReleaseDate;

/// <summary>
///     A release that has no date yet. To be announced.
/// </summary>
public sealed class NoReleaseDate : IReleaseDate
{
    /// <inheritdoc />
    public Optional<DateTimeOffset> GetDisplayDate()
    {
        return Optional<DateTimeOffset>.None();
    }
}
