using Ardalis.GuardClauses;

namespace NextUp.Domain;

public abstract class Entity
{
    protected Entity(EntityId id)
    {
        Guard.Against.Null(id);
        Id = id;
    }

    public EntityId Id { get; }
}
