using System.ComponentModel.DataAnnotations.Schema;

namespace AnnouncementsService.Domain.Entities;

/// <summary>
/// Объявление
/// </summary>
[Table("announcements")]
public class Announcement : Entity<long>
{
	/// <summary>
	/// Заголовок
	/// </summary>
	public required string Title { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Дата создания
	/// </summary>
	public DateTimeOffset CreateDate { get; set; }

	/// <summary>
	/// Дата обновления
	/// </summary>
	public DateTimeOffset? UpdateDate { get; set; }

	public int CategoryId { get; set; }
	/// <summary>
	/// Категория
	/// </summary>
	public virtual required Category Category { get; set; }

	/// <summary>
	/// Владелец
	/// </summary>
	//public required User Owner { get; set; }

}
