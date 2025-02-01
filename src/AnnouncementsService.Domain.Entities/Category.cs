namespace AnnouncementsService.Domain.Entities;

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

	public virtual Category? ParentCategory { get; set; }

	public int? ParentCategoryId { get; set; }

	public virtual List<Category>? ChildCategories { get; set; }

	public virtual List<Announcement>? Announcements { get; set; }

	// TODO: Добавить поля: набор фильтров
}
