namespace AnnouncementsService.Domain.Abstractions.Dto;

public class UserDto
{
	public required string Login { get; set; }

	public required string ExternalId { get; set; }
}
