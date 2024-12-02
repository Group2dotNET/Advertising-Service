using AdService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	public Task<IList<ShortAnnouncementDto>> GetAllAnnouncementsAsync();
}

public class ShortAnnouncementDto
{
	public int Id { get; set; }

	/// <summary>
	/// Заголовок объявления
	/// </summary>
	public required string Title { get; set; }
}