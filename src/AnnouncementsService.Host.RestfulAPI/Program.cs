using AnnouncementsSerivice.Application.Services;
using AnnouncementsService.Domain.Abstractions.Repositories;
using AnnouncementsService.Domain.Abstractions.Services;
using AnnouncementsService.Infrastructure.EfDbContext;
using AnnouncementsService.Infrastructure.Repositories;
using Mapster;
using MassTransit;
using System.Reflection;

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
		builder.Services.AddScoped<IAnnouncementsRepository, AnnouncementsRepository>()
						.AddScoped<ICategoriesRepository, CategoriesRepository>()
						.AddScoped<IUserRepository, UsersRepository>();
		builder.Services
			.AddTransient<IAnnouncementsService, AnnouncementsSerivice.Application.Services.AnnouncementsService>()
			.AddTransient<ICategoriesService, CategoriesService>()
			.AddTransient<IUserService, UserService>();

		builder.Services.AddMapster();
		TypeAdapterConfig
			.GlobalSettings
			.Scan(Assembly.GetExecutingAssembly());

		builder.Services.AddMassTransit(x =>
		{
			x.AddConsumer<UserConsumer>();
			x.UsingRabbitMq((context, cfg) =>
			{
				cfg.Host(new Uri(builder.Configuration["MessageBroker:Host"]), h =>
				{
					h.Username(builder.Configuration["MessageBroker:Username"]);
					h.Password(builder.Configuration["MessageBroker:Password"]);
				});

				cfg.ConfigureEndpoints(context);
			});
		});


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
