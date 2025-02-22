namespace AnnouncementsService.Domain.Abstractions.Dto;

public class CreatedAnnouncementDto
{
	public required string Title { get; set; }

	public string? Description { get; set; }

	public required string CategoryName { get; set; }

	public DateTimeOffset CreatedDate { get; set; }
}
