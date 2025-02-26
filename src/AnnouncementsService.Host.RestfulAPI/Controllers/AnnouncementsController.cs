using AnnouncementsService.Domain.Abstractions.Dto;
using AnnouncementsService.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsService.Host.RestfulAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController(IAnnouncementsService announcementsService) 
	: ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetAllAnnouncements()
	{
		try
		{
			var announcements = await announcementsService.GetAllAnnouncementsAsync();
			return Ok(announcements);
		}
		catch 
		{
			return BadRequest();
		}
	}

	[HttpGet]
	[Route("recent")]
	public async Task<IActionResult> GetRecentAnnouncementsPaged([FromQuery] PageInformation pageInfo)
	{
		try
		{
			var recentAnnouncements = await announcementsService.GetPagedRecentAnnouncementsAsync(pageInfo.PageNumber, pageInfo.PageSize);
			return Ok(recentAnnouncements);
		}
		catch 
		{
			return BadRequest();
		}
	}

	[HttpGet]
	[Route("{categoryName}")]
	public async Task<IActionResult> GetPagedAnnouncementsByCategory([FromQuery] PageInformation pageInfo, string categoryName)
	{
		try
		{
			var announcements = await announcementsService.GetPagedAnnouncementsByCategoryAsync(categoryName, pageInfo.PageNumber, pageInfo.PageSize);
			return Ok(announcements);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetAnnouncement(int id)
	{
		try
		{
			var announcement = await announcementsService.GetAnnouncementAsync(id);
			return Ok(announcement);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("create_new")]
	public async Task<IActionResult> CreateAnnouncement(CreatedAnnouncementDto newAnnouncement)
	{
		try
		{
			bool result = await announcementsService.CreateNewAnnouncementAsync(newAnnouncement);
			return Ok(result ? "Success" : "Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("edit")]
	public async Task<IActionResult> EditAnnouncement(EditedAnnouncementDto editedAnnouncementDto)
	{
		try
		{
			bool result = await announcementsService.UpdateAnnouncementAsync(editedAnnouncementDto);
			return Ok(result ? "Success" : "Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAnnouncement(int id)
	{
		try
		{
			bool result = await announcementsService.DeleteAnnouncementAsync(id);
			return Ok(result ? "Success" : "Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}

public class PageInformation
{
	public int PageNumber { get; set; }

	public int PageSize { get; set; }
}