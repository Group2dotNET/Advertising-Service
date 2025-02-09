using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Host.RestfulAPI.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsService.Host.RestfulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoriesService categoriesService, IMapper mapper) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllCategories()
	{
		try
		{
			var categories = await categoriesService.GetAllCategoriesWithSubcategories();
			var categoriesModel = categories is null 
				? null 
				: mapper.Map<IEnumerable<HierarchyCategoryDto>, IEnumerable<HierarchyCategoryModel>>(categories);
			return Ok(categoriesModel);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("general")]
	public async Task<IActionResult> GetGeneralCategories()
	{
		try
		{
			var generalCategories = (await categoriesService.GetGeneralCategoriesAsync())
				?.Select(c => new SimpleCategoryModel() { Name = c.Name });
			return Ok(generalCategories);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("{categoryName}")]
	public async Task<IActionResult> GetSubcategories(string categoryName)
	{
		try
		{
			var subcategories = (await categoriesService.GetGeneralSubcategoriesAsync(new ShortCategoryDto(categoryName)))
				?.Select(c => new SimpleCategoryModel() { Name = c.Name });
			return Ok(subcategories);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("editcategories/{categoryName}")]
	public async Task<IActionResult> GetEditingCategory(string categoryName)
	{
		try
		{
			var category = await categoriesService.GetCategoryAsync(categoryName);
			if (category == null) return BadRequest();
			return Ok(new EditingCategoryModel()
			{
				Name = category.Name,
				ParentCategoryName = category.ParentCategoryName,
				Characteristics = category.Characteristics,
				Filtres = category.Filtres
			});
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPost("editcategories/createcategory")]
	public async Task<IActionResult> SaveNewCategory(EditingCategoryModel category)
	{
		try
		{
			if (await categoriesService.SaveCategoryAsync(new FullCategoryDto(category.Name, category.ParentCategoryName,
				category.Characteristics, category.Filtres)))
				return Ok("Success");
			else
				return BadRequest("Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut("editcategories/{categoryName}")]
	public async Task<IActionResult> SaveCategory(string categoryName, EditingCategoryModel categoryData)
	{
		try
		{
			var category = await categoriesService.GetCategoryAsync(categoryName);
			if (category == null) return NotFound( new { Message = "Категория не найдена" });


			if (await categoriesService.SaveCategoryAsync(new FullCategoryDto(categoryData.Name, categoryData.ParentCategoryName,
				categoryData.Characteristics, categoryData.Filtres)))
				return Ok("Success");
			else
				return BadRequest("Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
