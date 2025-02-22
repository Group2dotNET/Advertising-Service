using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Entities;
using Mapster;

namespace AnnouncementsService.Host.RestfulAPI.Mapping;

public class AnnouncementProfile : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<Announcement, ShortAnnouncementDto>();
		config.NewConfig<Announcement, AnnouncementDto>()
			.Map(dest => dest.LastUpdateDate,
			src => src.UpdateDate ?? src.CreateDate);

		config.NewConfig<CreatedAnnouncementDto, Announcement>();
	}
}
