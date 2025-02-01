using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementsService.Infrastructure.Repositories
{
	public class AnnouncementsRepository(AnnouncementsDbContext dbContext) : IAnnouncementsRepository
	{
		private readonly AnnouncementsDbContext _dbContext = dbContext;

		public Task<bool> CreateAsync(Announcement entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(Announcement entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Announcement[]?> GetAllAsync()
			=> await _dbContext.Announcements.ToArrayAsync();

		public async Task<Announcement?> GetAsync(int key)
			=> await _dbContext.Announcements.SingleOrDefaultAsync(x => x.Id == key);

		public Task<bool> UpdateAsync(Announcement entity)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Announcement>?> GetAllRecentAsync()
		{
			var announcements = await GetAllAsync();
			return announcements?.OrderByDescending(x => x.CreateDate);
		}

		public async Task<Announcement[]?> GetAnnouncementsByCategoryAsync(int categoryId)
			=> await _dbContext.Announcements.Where(a => a.Category.Id == categoryId).OrderByDescending(x => x.CreateDate).ToArrayAsync();
	}
}
