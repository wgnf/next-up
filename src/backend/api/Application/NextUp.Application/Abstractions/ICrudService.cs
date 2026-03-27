using NextUp.Api.Commons.Functional;
using NextUp.Domain;

namespace NextUp.Application.Abstractions;

public interface ICrudService<TEntity>
    where TEntity : notnull
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<Optional<TEntity>> GetByIdAsync(EntityId id);
}
