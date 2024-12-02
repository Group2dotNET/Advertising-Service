using AdService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface IAnnouncementsRepository : ICrudRepository<Announcement, int>
{

}
