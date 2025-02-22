namespace AnnouncementsService.Domain.Abstractions.Dto;

/// <summary>
/// Объект для краткого представления объявления
/// </summary>
public class ShortAnnouncementDto
{
	/// <summary>
	/// Идентификатор объявления
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// Заголовок объявления
	/// </summary>
	public required string Title { get; set; }
}
