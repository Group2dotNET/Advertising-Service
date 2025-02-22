using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
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

	public async Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId)
	{
		var announcementsByCategory = await announcementsRepository.GetAnnouncementsByCategoryAsync(categoryId);
		return announcementsByCategory?.Select(a => new ShortAnnouncementDto
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
}
