using AnnouncementsService.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsService.Host.RestfulAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
	private readonly IAnnouncementsService _announcementsService;

	public AnnouncementsController(IAnnouncementsService announcementsService)
	{
		_announcementsService = announcementsService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAnnouncements()
	{
		try
		{
			var announcements = await _announcementsService.GetAllAnnouncementsAsync();
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
			var recentAnnouncements = await _announcementsService.GetAllRecentAnnouncementsAsync();
			return Ok(recentAnnouncements);
		}
		catch 
		{
			return BadRequest();
		}
	}
}