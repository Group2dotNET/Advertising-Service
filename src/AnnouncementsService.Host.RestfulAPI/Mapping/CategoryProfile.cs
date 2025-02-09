using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Host.RestfulAPI.Models;
using Mapster;

namespace AnnouncementsService.Host.RestfulAPI.Mapping
{
	public class CategoryProfile : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<HierarchyCategoryDto, HierarchyCategoryModel>();

			config.NewConfig<Category, HierarchyCategoryDto>();
		}
	}
}
