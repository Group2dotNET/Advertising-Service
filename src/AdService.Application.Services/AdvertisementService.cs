using AdService.Application.Abstractions.Services;
using AdService.Application.Contracts;
using AdService.Domain.Abstractions.Repositories;

namespace AdService.Application.Services
{
	public class AdvertisementService : IAdvertisementsService
	{
		private readonly IAdvertisementRepository _advertisementRepository;

		public AdvertisementService(IAdvertisementRepository advertisementRepository)
		{
			_advertisementRepository = advertisementRepository;
		}

		public async Task<IEnumerable<AdvertisementShortDto>> GetAllAdvertisements()
		{
			var advertisements = await _advertisementRepository.GetAllAsync();
			return advertisements.Select(a => new AdvertisementShortDto { Title = a.Title, LastPublishingDate = a.UpdateDate ?? a.CreateDate }) 
				?? Array.Empty<AdvertisementShortDto>();
		}
	}
}
