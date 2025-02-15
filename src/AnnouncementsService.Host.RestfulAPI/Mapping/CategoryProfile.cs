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
			config.NewConfig<Category, HierarchyCategoryDto>();
			config.NewConfig<Category, ShortCategoryDto>();
			config.NewConfig<Category, FullCategoryDto>()
				.TwoWays();

			config.NewConfig<HierarchyCategoryDto, HierarchyCategoryModel>();
			config.NewConfig<FullCategoryDto, EditingCategoryModel>()
				.TwoWays();
			config.NewConfig<ShortCategoryDto, SimpleCategoryModel>();
		}
	}
}
