using AnnouncementsService.Domain.Abstractions.Dto;

namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IUserService
{
	Task<bool> CreateUser(UserDto user);
}
