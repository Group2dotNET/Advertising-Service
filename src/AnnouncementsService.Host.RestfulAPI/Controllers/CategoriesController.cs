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
			var generalCategories = await categoriesService.GetGeneralCategoriesAsync();
			var categoryModels = generalCategories is null
				? null
				: mapper.Map<IEnumerable<SimpleCategoryModel>>(generalCategories);
			return Ok(categoryModels);
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
			var subcategories = await categoriesService.GetGeneralSubcategoriesAsync(new ShortCategoryDto(categoryName));
			var categoryModels = subcategories is null
				? null
				: mapper.Map<IEnumerable<SimpleCategoryModel>>(subcategories);
			return Ok(categoryModels);
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
			return Ok(mapper.Map<EditingCategoryModel>(category));
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
			if (await categoriesService.SaveCategoryAsync(mapper.Map<FullCategoryDto>(category)))
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


			if (await categoriesService.SaveCategoryAsync(mapper.Map<FullCategoryDto>(categoryData)))
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
