using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Infrastructure.EfDbContext;
using AnnouncementsService.Infrastructure.Repositories;

namespace AnnouncementsService.Host.RestfulAPI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.ConfigureDbContext();
		builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>();
		builder.Services
			.AddTransient<IAnnouncementsService, AnnouncementsSerivice.Application.Services.AnnouncementsService>();


		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.MapControllers();

		app.Run();
	}
}
