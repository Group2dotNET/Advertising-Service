using AdService.Domain.Abstractions.Repositories;
using AdService.Domain.Entities;
using AdService.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AdService.Infrastructure.Repositories
{
	public class AdvertisementsRepository : IAdvertisementRepository
	{

		public bool Add(Advertisement entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> AddAsync(Advertisement entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Advertisement entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(Advertisement entity)
		{
			throw new NotImplementedException();
		}

		public bool DeleteRange(IEnumerable<Advertisement> entities)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteRangeAsync(IEnumerable<Advertisement> entities)
		{
			throw new NotImplementedException();
		}

		public ICollection<Advertisement> GetAll()
		{
			using AdServiceDbContext adServiceDbContext = new();
			return adServiceDbContext.Advertisements.ToList();
		}

		public async Task<ICollection<Advertisement>> GetAllAsync()
		{
			await using AdServiceDbContext adServiceDbContext = new();
			return await adServiceDbContext.Advertisements.ToListAsync();
		}

		public Advertisement GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Advertisement> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Advertisement> GetPage(int page)
		{
			throw new NotImplementedException();
		}

		public Task<IQueryable<Advertisement>> GetPageAsync(int page)
		{
			throw new NotImplementedException();
		}

		public bool Update(Advertisement changedEntity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(Advertisement changedEntity)
		{
			throw new NotImplementedException();
		}
	}
}
