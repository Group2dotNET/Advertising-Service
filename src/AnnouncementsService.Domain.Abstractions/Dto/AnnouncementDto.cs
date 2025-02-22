namespace AnnouncementsService.Domain.Abstractions.Dto;

public class AnnouncementDto
{
	public long Id { get; set; }

	public required string Title { get; set; }

	public string? Description { get; set; }

	public required string CategoryName { get; set; }

	public DateTimeOffset LastUpdateDate { get; set; }
}