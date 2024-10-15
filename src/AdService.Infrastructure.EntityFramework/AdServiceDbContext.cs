using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdService.Infrastructure.EntityFramework
{
	public class AdServiceDbContext : DbContext
	{
		public DbSet<Advertisement> Advertisements { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<UserContactInfo> UsersContactInfo { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseNpgsql("Host=localhost;Database=adservicedb;Port=5432;Username=application_user;password=appuser");
		}
	}
}
