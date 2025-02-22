using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Domain.Entities;

namespace AnnouncementsSerivice.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
	public async Task<bool> CreateUser(UserDto userDto)
	{
		User user = new()
		{
			Login = userDto.Login,
			ExternalId = userDto.ExternalId
		};
		return await userRepository.CreateAsync(user);
	}
}
