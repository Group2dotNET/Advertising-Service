using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnnouncementsService.Infrastructure.EfDbContext;

public static class EntityFrameworkDbContextConfiguring
{
	public static void ConfigureDbContext(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddDbContext<AnnouncementsDbContext>((serviceProvider, options) =>
		{
			options.UseLazyLoadingProxies()
				.UseNpgsql(serviceProvider.GetRequiredService<IConfiguration>()
				.GetConnectionString("DatabaseConnection"),
				b => b.MigrationsAssembly("AnnouncementsService.Infrastructure.EfDbContext"));
		});
	}
}
