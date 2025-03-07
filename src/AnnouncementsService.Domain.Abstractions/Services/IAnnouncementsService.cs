﻿using AnnouncementsService.Domain.Abstractions.Dto;

namespace AnnouncementsService.Domain.Abstractions.Services;

public interface IAnnouncementsService
{
	Task<IList<ShortAnnouncementDto>?> GetAllAnnouncementsAsync();

	Task<IEnumerable<ShortAnnouncementDto>?> GetAllRecentAnnouncementsAsync();

	Task<AnnouncementDto> GetAnnouncementAsync(int id);

	Task<IEnumerable<ShortAnnouncementDto>?> GetPagedRecentAnnouncementsAsync(int pageNumber, int pageSize);

	Task<IEnumerable<ShortAnnouncementDto>> GetPagedAnnouncementsByCategoryAsync(string categoryName, int pageNumber, int pageSize);

	Task<bool> CreateNewAnnouncementAsync(CreatedAnnouncementDto newAnnouncement);

	Task<bool> UpdateAnnouncementAsync(EditedAnnouncementDto editedAnnouncement);

	Task<bool> DeleteAnnouncementAsync(int announcementId);
}