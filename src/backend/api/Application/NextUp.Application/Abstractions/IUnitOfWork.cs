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
    // TODO: why do I need to make this public explicitly? Check Rider Configuration or .editorconfig!
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
