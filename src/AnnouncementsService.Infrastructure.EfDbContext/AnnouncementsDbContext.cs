using Microsoft.EntityFrameworkCore;
using AnnouncementsService.Domain.Entities;

namespace AnnouncementsService.Infrastructure.EfDbContext;

public class AnnouncementsDbContext(DbContextOptions<AnnouncementsDbContext> options)
	: DbContext(options)
{
	public DbSet<Announcement> Announcements { get; set; }

	public DbSet<Category> Categories { get; set; }
}
