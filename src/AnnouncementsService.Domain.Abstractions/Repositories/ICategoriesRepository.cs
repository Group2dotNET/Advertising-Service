using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

/// <summary>
/// Репозиторий категорий
/// </summary>
public interface ICategoriesRepository : ICrudRepository<Category, int>
{
	/// <summary>
	/// Получить основные категории
	/// </summary>
	/// <returns>Список основных категорий</returns>
	Task<Category[]?> GetGeneralCategories();

	/// <summary>
	/// Получить категорию по имени
	/// </summary>
	/// <param name="name">Имя категории</param>
	/// <returns>Категория</returns>
	Task<Category?> GetCategoryByNameAsync(string name);

	/// <summary>
	/// Получить список дочерних категорий для категории по её имени
	/// </summary>
	/// <param name="categoryName">Имя категории</param>
	/// <returns>Список дочерних категорий</returns>
	Task<IEnumerable<Category>?> GetSubcategories(string categoryName);

	Task<int?> GetCategoryIdByNameAsync(string categoryName);
}
