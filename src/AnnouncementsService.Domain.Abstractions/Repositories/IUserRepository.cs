using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Domain.Abstractions.Repositories;

public interface IUserRepository : ICrudRepository<User, Guid>
{
}
