using Ardalis.GuardClauses;

namespace NextUp.Domain;

public sealed record EntityId
{
    private EntityId(string idValue)
    {
        Guard.Against.NullOrWhiteSpace(idValue);

        IdValue = idValue;
    }

    public string IdValue { get; }

    public static EntityId CreateNew()
    {
        // TODO: new YT-style ID?!
        var newId = Guid.NewGuid().ToString("N");
        var entityId = new EntityId(newId);
        return entityId;
    }

    public static EntityId FromIdString(string existingId)
    {
        Guard.Against.NullOrWhiteSpace(existingId);

        var entityId = new EntityId(existingId);
        return entityId;
    }

    public override string ToString()
    {
        return IdValue;
    }
}
