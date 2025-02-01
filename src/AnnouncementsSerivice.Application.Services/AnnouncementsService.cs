using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Domain.Entities;

namespace AnnouncementsSerivice.Application.Services;

public class AnnouncementsService(IAnnouncementsRepository announcementsRepository,
								ICategoriesRepository categoriesRepository) : IAnnouncementsService
{

	public async Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync()
	{
		var announcements = await announcementsRepository.GetAllAsync();
		return announcements?
			.Select(a => new ShortAnnouncementDto()
			{
				Id = a.Id,
				Title = a.Title
			}).ToList();
	}

	public async Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync()
	{
		var recentAnnouncements = await announcementsRepository.GetAllRecentAsync();
		return recentAnnouncements?.Select(a => new ShortAnnouncementDto()
		{
			Id = a.Id,
			Title = a.Title,
		});
	}

	public async Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId)
	{
		var announcementsByCategory = await announcementsRepository.GetAnnouncementsByCategoryAsync(categoryId);
		return announcementsByCategory?.Select(a => new ShortAnnouncementDto
		{
			Id = a.Id,
			Title = a.Title,
		});
	}

	public async Task<AnnouncementDto> GetAnnouncement(int id)
	{
		var announcement = await announcementsRepository.GetAsync(id);
		if (announcement == null)
		{
			throw new Exception("Ошибка! Объявления не найдено");
		}

		return new AnnouncementDto
		{
			Id = announcement.Id,
			Title = announcement.Title,
			Description = announcement.Description,
			CategoryName = announcement.Category.Name,
			LastUpdateDate = announcement.UpdateDate ?? announcement.CreateDate
		};
	}

	public async Task<bool> CreateAnnouncement(AnnouncementDto announcement)
	{
		Category category = new() { Name = "Test" }; //await categoriesRepository.GetCategoryByNameAsync(announcement.CategoryName);
		return await announcementsRepository.CreateAsync(new Announcement()
		{
			Category = category,
			Title = announcement.Title,
			Description = announcement.Description,
			CreateDate = DateTimeOffset.Now
		});
	}
}
