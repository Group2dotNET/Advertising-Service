namespace AdService.Domain.Entities;

/// <summary>
/// Категория
/// </summary>
public class Category : Entity
{
	/// <summary>
	/// Имя категории
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Описание категории
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Родительская категория
	/// </summary>
	public Category? ParentCategory { get; set; }

	public int? ParentCategoryId { get; set; }
}
