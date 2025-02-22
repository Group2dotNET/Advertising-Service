using AnnouncementsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnnouncementsService.Infrastructure.EfDbContext.Configurations;

internal class UsersConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("users")
			   .Property(u => u.Id)
			   .HasColumnName("user_id");
		builder.HasKey(u => u.Id).HasName("users_primary_key");

		builder.Property(u => u.Login)
			.HasColumnName("login");
		builder.HasIndex(u => u.Login)
			.IsUnique()
			.HasDatabaseName("IX_Login_Ascending");

		builder.Property(u => u.ExternalId)
			.HasColumnName("external_id");
	}
}
