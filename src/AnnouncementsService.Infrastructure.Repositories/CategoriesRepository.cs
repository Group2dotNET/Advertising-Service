using Microsoft.EntityFrameworkCore;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext;

namespace AnnouncementsService.Infrastructure.Repositories;

public class CategoriesRepository(AnnouncementsDbContext dbContext) : ICategoriesRepository
{
	#region ICrudRepository
	public async Task<bool> CreateAsync(Category entity)
	{
		dbContext.Categories.Add(entity);
		return await dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(Category entity)
	{
		dbContext.Remove(entity);
		return await dbContext.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<Category>?> GetAllAsync()
		=> await dbContext.Categories.OrderBy(c => c.Name).ToArrayAsync();

	public async Task<Category?> GetAsync(int key)
		=> await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == key);

	public async Task<bool> UpdateAsync(Category entity)
	{
		var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == entity.Id);
		if (category == null) return false;

		category.Name = entity.Name;
		category.ParentCategoryId = entity.ParentCategoryId;
		category.Characteristics = entity.Characteristics;
		category.Filtres = entity.Filtres;

		return await dbContext.SaveChangesAsync() > 0;
	}
	#endregion

	public async Task<Category[]?> GetGeneralCategories()
		=> await dbContext.Categories.Where(c => c.ParentCategory == null).ToArrayAsync();

	public async Task<Category?> GetCategoryByNameAsync(string name)
		=> await dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Name == name);

	public async Task<IEnumerable<Category>?> GetSubcategories(string categoryName)
	{
		var category = await dbContext.Categories.AsNoTracking().SingleAsync(c => c.Name == categoryName);
		return category.ChildCategories;
	}

	public async Task<int?> GetCategoryIdByNameAsync(string categoryName)
	{
		var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
		return category?.Id;
	}
}
