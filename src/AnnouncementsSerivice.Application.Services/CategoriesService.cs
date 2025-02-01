using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;

namespace AnnouncementsSerivice.Application.Services;

public class CategoriesService(ICategoriesRepository categoriesRepository) : ICategoriesService
{
	public async Task<IEnumerable<CategoryDto>?> GetAllCategories()
		=> (await categoriesRepository.GetAllAsync())?.Select(c => new CategoryDto { Id = c.Id, CategoryName = c.Name });

	public async Task<IEnumerable<CategoryDto>?> GetGeneralCategories()
		=> (await categoriesRepository.GetGeneralCategories())?.Select(c => new CategoryDto { Id = c.Id, CategoryName = c.Name });
}
