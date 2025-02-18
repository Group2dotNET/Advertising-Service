﻿namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAnnouncementsByCategory(int categoryId);

	Task<AnnouncementDto> GetAnnouncement(int id);

	//Task<bool> CreateAnnouncement(AnnouncementDto announcement);
}

public class ShortAnnouncementDto
{
	public long Id { get; set; }

	/// <summary>
	/// Заголовок объявления
	/// </summary>
	public required string Title { get; set; }
}

public class AnnouncementDto
{
	public long Id { get; set; }

	public required string Title { get; set; }

	public string? Description { get; set; }

	public required string CategoryName { get; set; }

	public DateTimeOffset LastUpdateDate { get; set; }
}