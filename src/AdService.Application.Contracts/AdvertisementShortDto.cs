namespace AdService.Application.Contracts;

public class AdvertisementShortDto
{
	public required string Title { get; set; }

	public DateTimeOffset LastPublishingDate { get; set; }
}
