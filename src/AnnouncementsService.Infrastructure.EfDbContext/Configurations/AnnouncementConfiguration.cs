using AnnouncementsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnnouncementsService.Infrastructure.EfDbContext.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
	public void Configure(EntityTypeBuilder<Announcement> builder)
	{
		builder.ToTable("announcements").Property(a => a.Id)
			.HasColumnName("announcement_id");
		builder.HasKey(a => a.Id).HasName("announcements_primary_key");
		builder.Property(a => a.Title)
			.HasColumnName("title");
		builder.Property(a => a.Description)
			.HasColumnName("description");
		builder.Property(a => a.CreateDate)
			.HasColumnName("create_date");
		builder.Property(a => a.UpdateDate)
			.HasColumnName("update_date");
		builder.Property(a => a.CategoryId)
			.HasColumnName("category_id");
		builder.HasOne(a => a.Category)
			   .WithMany(c => c.Announcements)
			   .HasForeignKey(a => a.CategoryId);
		builder.HasOne(a => a.Owner)
			   .WithMany(u => u.Announcements)
			   .HasForeignKey(a => a.OwnerId);
	}
}
