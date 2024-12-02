namespace AdService.Domain.Entities;

/// <summary>
/// Категория
/// </summary>
public class Category : Entity<int>
{
	/// <summary>
	/// Наименование категории
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Описание категории
	/// </summary>
	public string? Description { get; set; }

	public Category? ParentCategory { get; set; }

	//public int? ParentCategoryId { get; set; }

	// TODO: Добавить поля: набор фильтров
}
