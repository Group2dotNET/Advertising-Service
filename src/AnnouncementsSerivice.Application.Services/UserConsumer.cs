using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Services;
using Contracts;
using MassTransit;

namespace AnnouncementsSerivice.Application.Services;

public class UserConsumer(IUserService userService) : IConsumer<UserRegisterInfoDto>
{

	public async Task Consume(ConsumeContext<UserRegisterInfoDto> context)
	{
		UserRegisterInfoDto userInfo = context.Message;
		try
		{
			UserDto userDto = new()
			{
				Login = userInfo.UserName,
				ExternalId = userInfo.Id
			};
			await userService.CreateUser(userDto);
		}
		catch (Exception ex)
		{
			return;
		}
	}
}
