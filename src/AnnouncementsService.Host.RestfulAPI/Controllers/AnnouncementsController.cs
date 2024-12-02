using AnnouncementsService.Domain.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsService.Host.RestfulAPI.Controllers
{
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
				await _announcementsService.GetAllAnnouncementsAsync();
			}
			catch { }
			return Ok();
		}
	}
}
