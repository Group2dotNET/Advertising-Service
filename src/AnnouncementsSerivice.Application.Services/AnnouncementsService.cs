using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Domain.Entities;
using MapsterMapper;

namespace AnnouncementsSerivice.Application.Services;

public class AnnouncementsService(IAnnouncementsRepository announcementsRepository, ICategoriesService categoriesService,
	IMapper mapper) : IAnnouncementsService
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

	public async Task<AnnouncementDto> GetAnnouncementAsync(int id)
	{
		var announcement = await announcementsRepository.GetAsync(id);
		if (announcement == null)
		{
			throw new Exception("Ошибка! Объявления не найдено");
		}
		return mapper.Map<AnnouncementDto>(announcement);
	}

	public async Task<IEnumerable<ShortAnnouncementDto>?> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize)
		=> mapper.Map<IEnumerable<ShortAnnouncementDto>>(await announcementsRepository.GetPagedRecentAnnouncementsAsync(pageNumber, pageSize));

	public async Task<IEnumerable<ShortAnnouncementDto>> GetPagedAnnouncementsByCategoryAsync(string categoryName, int pageNumber, int pageSize)
	{
		var categoryId = await categoriesService.GetCategoryIdByNameAsync(categoryName);
		if(!categoryId.HasValue)
		{
			throw new Exception($"Отсутсвует категория с именем {categoryName}");
		}

		return mapper.Map<IEnumerable<ShortAnnouncementDto>>(
			await announcementsRepository
				.GetPagedAnnouncementsByCategoryIdAsync(categoryId.Value, pageNumber, pageSize));
	}

	public async Task<bool> CreateNewAnnouncementAsync(CreatedAnnouncementDto newAnnouncement)
	{
		try
		{
			int? category = await categoriesService.GetCategoryIdByNameAsync(newAnnouncement.CategoryName);
			if (category == null)
			{
				throw new Exception($"Отсутсвует категория с именем {newAnnouncement.CategoryName}");
			}
			var announcement = new Announcement()
			{
				Title = newAnnouncement.Title,
				Description = newAnnouncement.Description,
				CategoryId = category.Value,
				CreateDate = DateTimeOffset.UtcNow
			};

			return await announcementsRepository.CreateAsync(announcement);
		}
		catch
		{
			throw;
		}
	}

	public async Task<bool> UpdateAnnouncementAsync(EditedAnnouncementDto editedAnnouncement)
	{
		var announcement = await announcementsRepository.GetAsync(editedAnnouncement.Id);
		var categoryId = await categoriesService.GetCategoryIdByNameAsync(editedAnnouncement.CategoryName);
		if (announcement == null)
			throw new Exception($"Объявления с идентификатором {editedAnnouncement.Id} не существует");
		if (categoryId == null)
			throw new Exception($"Отсутсвует категория с именем {editedAnnouncement.CategoryName}");

		announcement.Title = editedAnnouncement.Title;
		announcement.Description = editedAnnouncement.Description;
		announcement.CategoryId = categoryId.Value;
		announcement.UpdateDate = DateTimeOffset.UtcNow;
		
		return await announcementsRepository.UpdateAsync(announcement);
	}
}
