namespace AnnouncementsService.Domain.Abstractions.Services;

public interface ICategoriesService
{
	Task<IEnumerable<CategoryDto>?> GetAllCategories();

	Task<IEnumerable<CategoryDto>?> GetGeneralCategories();

	Task<CategoryDto?> GetCategoryByName(string categoryName);
}

public class CategoryDto
{
	public int Id { get; set; }

	public required string CategoryName { get; set; }
}
