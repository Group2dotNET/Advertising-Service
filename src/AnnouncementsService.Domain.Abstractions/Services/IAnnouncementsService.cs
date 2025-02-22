using AnnouncementsService.Domain.Abstractions.Dto;

namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId);

	Task<AnnouncementDto> GetAnnouncementAsync(int id);

	Task<IEnumerable<ShortAnnouncementDto>?> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize);

	Task<IEnumerable<ShortAnnouncementDto>> GetPagedAnnouncementsByCategoryAsync(string categoryName, int pageNumber, int pageSize);
}