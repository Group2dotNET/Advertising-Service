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

		public async Task<IEnumerable<Announcement>?> GetAllAsync()
			=> await _dbContext.Announcements.ToArrayAsync();

		public Task<Announcement?> GetAsync(int key)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(Announcement entity)
		{
			throw new NotImplementedException();
		}
	}
}
