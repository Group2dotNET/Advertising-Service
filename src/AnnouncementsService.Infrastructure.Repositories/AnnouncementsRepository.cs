using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementsService.Infrastructure.Repositories
{
	public class AnnouncementsRepository(AnnouncementsDbContext dbContext) : IAnnouncementsRepository
	{
		private readonly AnnouncementsDbContext _dbContext = dbContext;

		public async Task<bool> CreateAsync(Announcement entity)
		{
			_dbContext.Announcements.Add(entity);
			return (await _dbContext.SaveChangesAsync()) > 0;
		}

		public async Task<bool> DeleteAsync(int entityId)
		{
			var announcement = await _dbContext.Announcements.SingleOrDefaultAsync(a => a.Id == entityId);
			if (announcement != null)
			{
				_dbContext.Announcements.Remove(announcement);
				_dbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<IEnumerable<Announcement>?> GetAllAsync()
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
