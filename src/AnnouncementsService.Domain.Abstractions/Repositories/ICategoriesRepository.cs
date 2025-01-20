using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface ICategoriesRepository : ICrudRepository<Category, int>
{
	Task<Category[]?> GetGeneralCategories();
}
