﻿using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Domain.Entities;
using MapsterMapper;
using System.Diagnostics;

namespace AnnouncementsSerivice.Application.Services;

public class CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper) : ICategoriesService
{
	public async Task<bool> DeleteCategoryAsync(FullCategoryDto category)
	{
		try
		{
			var categoryEntity = await categoriesRepository.GetCategoryByNameAsync(category.Name);
			return categoryEntity == null
				? throw new Exception($"Категории с таким именем не существует [Name={category.Name}]")
				: await categoriesRepository.DeleteAsync(categoryEntity);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			throw;
		}
	}

	public async Task<IEnumerable<HierarchyCategoryDto>?> GetAllCategoriesWithSubcategories()
	{
		try
		{
			var allCategories = (await categoriesRepository.GetAllAsync())?.ToArray();
			if (allCategories is null) return null;
			var hierarchyCategories = mapper.Map<IEnumerable<Category>, IEnumerable<HierarchyCategoryDto>>
				(allCategories.Where(c => c.ParentCategoryId == null));
			return hierarchyCategories;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			throw;
		}
	}

	public async Task<FullCategoryDto?> GetCategoryAsync(string categoryName)
	{
		var category = await categoriesRepository.GetCategoryByNameAsync(categoryName);
		return category is null
			? null
			: new FullCategoryDto(category.Id, category.Name, category.ParentCategory?.Name ?? "", category.Characteristics ?? "", category.Filtres ?? "");
	}

	public async Task<IEnumerable<ShortCategoryDto>?> GetGeneralCategoriesAsync()
		=> (await categoriesRepository.GetGeneralCategories())
			?.Select(c => new ShortCategoryDto(c.Name));

	public async Task<IEnumerable<ShortCategoryDto>?> GetGeneralSubcategoriesAsync(ShortCategoryDto category)
		=> (await categoriesRepository.GetSubcategories(category.Name))
			?.Select(c => new ShortCategoryDto(c.Name));

	public async Task<bool> CreateCategoryAsync(FullCategoryDto savedCategory)
	{
		var parentCategoryId = savedCategory.ParentCategoryName is null 
			? null 
			: await categoriesRepository.GetCategoryIdByNameAsync(savedCategory.ParentCategoryName);
		return await categoriesRepository.CreateAsync(
			new Category()
			{
				Name = savedCategory.Name,
				ParentCategoryId = parentCategoryId,
				Characteristics = savedCategory.Characteristics,
				Filtres = savedCategory.Filtres,
			});
	}

	public async Task<bool> UpdateCategoryAsync(FullCategoryDto originalCategory, FullCategoryDto updatedCategory)
	{
		int? parentCategoryId = null;
		if(updatedCategory.ParentCategoryName is not null)
			parentCategoryId = await categoriesRepository.GetCategoryIdByNameAsync(updatedCategory.ParentCategoryName);

		return await categoriesRepository.UpdateAsync(new()
		{
			Id = originalCategory.Id,
			Name = updatedCategory.Name,
			ParentCategoryId = parentCategoryId,
			Characteristics = updatedCategory.Characteristics,
			Filtres = updatedCategory.Filtres
		});
	}

	public async Task<int?> GetCategoryIdByNameAsync(string categoryName)
		=> await categoriesRepository.GetCategoryIdByNameAsync(categoryName);
}
