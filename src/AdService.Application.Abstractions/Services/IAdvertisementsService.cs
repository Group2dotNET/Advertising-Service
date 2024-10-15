using AdService.Application.Contracts;

namespace AdService.Application.Abstractions.Services;

public interface IAdvertisementsService
{
	Task<IEnumerable<AdvertisementShortDto>> GetAllAdvertisements();
}
