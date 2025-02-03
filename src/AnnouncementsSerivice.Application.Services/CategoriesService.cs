using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Domain.Entities;
using System.Diagnostics;

namespace AnnouncementsSerivice.Application.Services;

public class CategoriesService(ICategoriesRepository categoriesRepository) : ICategoriesService
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

	public async Task<IEnumerable<HierarchyCategoryDto>> GetAllCategoriesHierarchyAsync()
	{
		try
		{
			var generalCategories = ((await GetGeneralCategoriesAsync())?.Select(c => new HierarchyCategoryDto(c.Name, []))) 
				?? throw new Exception($"Основные категории отсутствуют");
			await FillInSubcategoriesAsync(generalCategories);
			return generalCategories;
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
			: new FullCategoryDto(category.Name, category.ParentCategory?.Name ?? "", category.Characteristics ?? "", category.Filtres ?? "");
	}

	public async Task<IEnumerable<ShortCategoryDto>?> GetGeneralCategoriesAsync()
		=> (await categoriesRepository.GetGeneralCategories())
			?.Select(c => new ShortCategoryDto(c.Name));

	public async Task<IEnumerable<ShortCategoryDto>?> GetGeneralSubcategoriesAsync(ShortCategoryDto category)
		=> (await categoriesRepository.GetSubcategories(category.Name))
			?.Select(c => new ShortCategoryDto(c.Name));

	public async Task<bool> SaveCategoryAsync(FullCategoryDto savedCategory)
	{
		var category = await categoriesRepository.GetCategoryByNameAsync(savedCategory.Name);
		if (category is null)
		{
			var parentCategory = await categoriesRepository.GetCategoryByNameAsync(savedCategory.ParentCategoryName);
			return await categoriesRepository.CreateAsync(
												new Category()
												{
													Name = savedCategory.Name,
													ParentCategoryId = parentCategory?.Id,
													Characteristics = savedCategory.Characteristics,
													Filtres = savedCategory.Filtres,
												});
		}
		else
		{
			return await categoriesRepository.UpdateAsync(category);
		}
	}

	private async Task FillInSubcategoriesAsync(IEnumerable<HierarchyCategoryDto> parentCategories)
	{
		foreach (HierarchyCategoryDto parentCategory in parentCategories)
		{
			var subcategories = (await GetGeneralSubcategoriesAsync(new(parentCategory.Name)))
				?.Select(s => new HierarchyCategoryDto(s.Name, []));
			if (subcategories != null)
			{
				await FillInSubcategoriesAsync(subcategories);
				parentCategory.Subcategories.AddRange(subcategories);
			}
		}
	}
}
