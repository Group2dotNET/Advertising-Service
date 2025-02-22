using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface IAnnouncementsRepository : ICrudRepository<Announcement, int>
{
	Task<IEnumerable<Announcement>?> GetAllRecentAsync();

	Task<IEnumerable<Announcement>> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize);

	Task<IEnumerable<Announcement>> GetPagedAnnouncementsByCategoryIdAsync(int categoryId, int pageNumber, int pageSize);
}
