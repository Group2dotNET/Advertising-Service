using Microsoft.EntityFrameworkCore;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext;

namespace AnnouncementsService.Infrastructure.Repositories;

public class CategoriesRepository(AnnouncementsDbContext dbContext) : ICategoriesRepository
{
	public Task<bool> CreateAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Category>?> GetAllAsync()
		=> await dbContext.Categories.OrderBy(c => c.Name).ToArrayAsync();

	public Task<Category?> GetAsync(int key)
	{
		throw new NotImplementedException();
	}

	public Task<bool> UpdateAsync(Category entity)
	{
		throw new NotImplementedException();
	}

	public async Task<Category[]?> GetGeneralCategories()
		=> await dbContext.Categories.Where(c => c.ParentCategory == null).ToArrayAsync();

	public async Task<Category?> GetCategoryByNameAsync(string name)
		=> await dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Name == name);
}
