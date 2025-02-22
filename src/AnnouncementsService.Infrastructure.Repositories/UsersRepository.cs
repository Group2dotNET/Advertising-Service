using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementsService.Infrastructure.Repositories;

public class UsersRepository(AnnouncementsDbContext dbContext) : IUserRepository
{
	public async Task<bool> CreateAsync(User entity)
	{
		dbContext.Users.Add(entity);
		return (await dbContext.SaveChangesAsync()) > 0;
	}

	public Task<bool> DeleteAsync(User entity)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<User>?> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<User?> GetAsync(Guid key)
	{
		return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == key);
	}

	public async Task<bool> UpdateAsync(User entity)
	{
		var user = await GetAsync(entity.Id);
		if (user == null)
			return false;

		dbContext.Users.Update(entity);
		return (await dbContext.SaveChangesAsync()) > 0;
	}
}
