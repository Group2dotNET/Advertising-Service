using AnnouncementsService.Domain.Abstractions.Dto;

namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId);

	Task<AnnouncementDto> GetAnnouncementAsync(int id);

	//Task<bool> CreateAnnouncement(AnnouncementDto announcement);

	Task<IEnumerable<ShortAnnouncementDto>?> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize);

	Task<IEnumerable<ShortAnnouncementDto>> GetPagedAnnouncementsByCategoryAsync(string categoryName, int pageNumber, int pageSize);
}

public class AnnouncementDto
{
	public long Id { get; set; }

	public required string Title { get; set; }

	public string? Description { get; set; }

	public required string CategoryName { get; set; }

	public DateTimeOffset LastUpdateDate { get; set; }
}