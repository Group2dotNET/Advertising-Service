namespace AnnouncementsService.Domain.Abstractions.Dto;

public class EditedAnnouncementDto
{
	public int Id { get; set; }

	public required string Title { get; set; }

	public string? Description { get; set; }

	public required string CategoryName { get; set; }

	public DateTimeOffset CreatedDate { get; set; }

	public DateTimeOffset UpdatedDate { get; set; }
}
