using System.Text.Json.Serialization;
using NextUp.Domain.Games;

namespace NextUp.Api.Games;

[JsonSerializable(typeof(IEnumerable<GameDeveloper>))]
public partial class GamesJsonContext : JsonSerializerContext;
