namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface ICrudRepository<TEntity, TKey>
{
	Task<TEntity[]?> GetAllAsync();

	Task<TEntity?> GetAsync(TKey key);

	Task<bool> CreateAsync(TEntity entity);

	Task<bool> UpdateAsync(TEntity entity);

	Task<bool> DeleteAsync(TEntity entity);
}
