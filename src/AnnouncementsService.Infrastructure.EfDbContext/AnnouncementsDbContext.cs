using Microsoft.EntityFrameworkCore;
using AnnouncementsService.Domain.Entities;
using AnnouncementsService.Infrastructure.EfDbContext.Configurations;

namespace AnnouncementsService.Infrastructure.EfDbContext;

public class AnnouncementsDbContext(DbContextOptions<AnnouncementsDbContext> options)
	: DbContext(options)
{
	public DbSet<Announcement> Announcements { get; set; }

	public DbSet<Category> Categories { get; set; }

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
		modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
		modelBuilder.ApplyConfiguration(new UsersConfiguration());
	}
}
