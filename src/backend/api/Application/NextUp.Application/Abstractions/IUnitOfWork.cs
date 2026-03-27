namespace NextUp.Application.Abstractions;

/*
 * NOTE:
 * Bundles a "transaction over multiple repositories"
 *
 * Example:
 * DeveloperRepository.Add(developer)
 * GameRepository.Add(game)
 * ReleaseRepository.Add(release)
 * UnitOfWork.SaveChanges()
 */

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
