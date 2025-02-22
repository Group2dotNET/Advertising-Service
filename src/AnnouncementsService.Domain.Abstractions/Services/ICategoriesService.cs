using AnnouncementsService.Domain.Abstractions.Dto;

namespace AnnouncementsService.Domain.Abstractions.Services;

/// <summary>
/// Севрис для работы с категориями
/// </summary>
public interface ICategoriesService
{
	/// <summary>
	/// Получение всех категорий в иерархическом виде
	/// </summary>
	/// <returns>Список всех категорий в иерархическом виде</returns>
	Task<IEnumerable<HierarchyCategoryDto>?> GetAllCategoriesWithSubcategories();

	/// <summary>
	/// Получение основных категорий
	/// </summary>
	/// <returns>Список основных категорий</returns>
	Task<IEnumerable<ShortCategoryDto>?> GetGeneralCategoriesAsync();

	/// <summary>
	/// Получение категории
	/// </summary>
	/// <param name="categoryName">Имя категории</param>
	/// <returns>Объект категории</returns>
	Task<FullCategoryDto?> GetCategoryAsync(string categoryName);

	/// <summary>
	/// Сохранить категорию
	/// </summary>
	/// <param name="category">Сохраняемая категория</param>
	/// <returns>Результат сохранения</returns>
	Task<bool> SaveCategoryAsync(FullCategoryDto category);

	/// <summary>
	/// Удаление категории
	/// </summary>
	/// <param name="category">Удалаяемая категория</param>
	/// <returns>Результат удаления</returns>
	Task<bool> DeleteCategoryAsync(FullCategoryDto category);

	/// <summary>
	/// Получить все основные подкатегории
	/// </summary>
	/// <param name="category">Объект категории, у которой нужно получить подкатегории</param>
	/// <returns>Список основных подкатегорий</returns>
	Task<IEnumerable<ShortCategoryDto>?> GetGeneralSubcategoriesAsync(ShortCategoryDto category);

	Task<int?> GetCategoryIdByNameAsync(string categoryName);
}
