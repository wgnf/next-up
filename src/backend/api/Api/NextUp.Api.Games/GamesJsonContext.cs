using System.Text.Json.Serialization;
using NextUp.Api.Games.GameDevelopers;

namespace NextUp.Api.Games;

[JsonSerializable(typeof(GameDev[]))]
public partial class GamesJsonContext : JsonSerializerContext;
