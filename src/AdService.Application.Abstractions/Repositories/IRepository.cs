using AdService.Domain.Entities;

namespace AdService.Domain.Abstractions.Repositories;

public interface IRepository<T> 
	where T : Entity
{
	public T GetById(int id);

	public Task<T> GetByIdAsync(int id);

	public ICollection<T> GetAll();

	public Task<ICollection<T>> GetAllAsync();

	public IQueryable<T> GetPage(int page);

	public Task<IQueryable<T>> GetPageAsync(int page);

	public bool Add(T entity);

	public Task<bool> AddAsync(T entity);

	public bool Update(T changedEntity);

	public Task<bool> UpdateAsync(T changedEntity);

	public bool Delete(T entity);

	public Task<bool> DeleteAsync(T entity);

	public bool DeleteRange(IEnumerable<T> entities);

	public Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
}
