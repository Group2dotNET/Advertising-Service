namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();
}

public class ShortAnnouncementDto
{
	public long Id { get; set; }

	/// <summary>
	/// Заголовок объявления
	/// </summary>
	public required string Title { get; set; }
}