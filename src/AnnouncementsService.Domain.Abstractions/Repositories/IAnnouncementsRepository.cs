using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface IAnnouncementsRepository : ICrudRepository<Announcement, int>
{
	Task<IEnumerable<Announcement>?> GetAllRecentAsync();

	Task<Announcement[]?> GetAnnouncementsByCategoryAsync(int categoryId);

	Task<IEnumerable<Announcement>> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize);
}
