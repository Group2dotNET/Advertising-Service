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
	public virtual Category? Category { get; set; }

	public Guid? OwnerId { get; set; }
	/// <summary>
	/// Владелец
	/// </summary>
	public virtual User? Owner { get; set; }

}
