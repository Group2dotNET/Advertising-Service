using AnnouncementsService.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsService.Host.RestfulAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController(IAnnouncementsService announcementsService, ICategoriesService categoriesService) 
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
	[Route("/Home/Announcements/")]
	public async Task<IActionResult> GetAllRecentAnnouncements()
	{
		try
		{
			var recentAnnouncements = await announcementsService.GetAllRecentAnnouncementsAsync();
			return Ok(recentAnnouncements);
		}
		catch 
		{
			return BadRequest();
		}
	}

	[HttpGet]
	[Route("/Home/Categories")]
	public async Task<IActionResult> GetGeneralCategories()
	{
		try
		{
			var generalCategories = await categoriesService.GetGeneralCategories();
			return Ok(generalCategories);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("/Home/Categories/{id}")]
	public async Task<IActionResult> GetAnnouncementsByCategory(int id)
	{
		try
		{
			var announcementsByCategory = await announcementsService.GetAnnouncementsByCategory(id);
			return Ok(announcementsByCategory);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("/Home/Announcements/{id}")]
	public async Task<IActionResult> GetAnnouncement(int id)
	{
		try
		{
			var announcement = await announcementsService.GetAnnouncement(id);
			return Ok(announcement);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("/Home/Announcements/CreateNew")]
	public async Task<IActionResult> CreateAnnouncement(AnnouncementDto announcement)
	{
		try
		{
			bool result = await announcementsService.CreateAnnouncement(announcement);
			return Ok(result ? "Success" : "Fail");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}