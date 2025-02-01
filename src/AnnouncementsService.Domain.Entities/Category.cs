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
	/// Идентификатор родительской категории
	/// </summary>
	public int? ParentCategoryId { get; set; }

	#region Navigation Properties
	/// <summary>
	/// Список подкатегорий
	/// </summary>
	public virtual List<Category>? ChildCategories { get; set; }

	/// <summary>
	/// Список объявлений, которые принадлежать данной категории
	/// </summary>
	public virtual List<Announcement>? Announcements { get; set; }

	/// <summary>
	/// Родительская категория
	/// </summary>
	public virtual Category? ParentCategory { get; set; }
	#endregion

	// TODO: Добавить поля: набор фильтров, набор характеристик, изображение категории
}
