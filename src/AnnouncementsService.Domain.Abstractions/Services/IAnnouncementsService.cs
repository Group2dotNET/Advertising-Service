namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId);
}

public class ShortAnnouncementDto
{
	public long Id { get; set; }

	/// <summary>
	/// Заголовок объявления
	/// </summary>
	public required string Title { get; set; }
}