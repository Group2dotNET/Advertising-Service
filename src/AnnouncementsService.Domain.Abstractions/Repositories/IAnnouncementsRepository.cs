using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface IAnnouncementsRepository : ICrudRepository<Announcement, int>
{
	public Task<IEnumerable<Announcement>?> GetAllRecentAsync();

	public Task<Announcement[]?> GetAnnouncementsByCategoryAsync(int categoryId);
}
