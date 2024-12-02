using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;

namespace AnnouncementsSerivice.Application.Services;

public class AnnouncementsService(IAnnouncementsRepository announcementsRepository) : IAnnouncementsService
{
	private readonly IAnnouncementsRepository _announcementsRepository = announcementsRepository;

	public async Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync()
	{
		var announcements = await _announcementsRepository.GetAllAsync();
		return announcements?
			.Select(a => new ShortAnnouncementDto()
			{
				Id = a.Id,
				Title = a.Title
			}).ToList();
	}
}
