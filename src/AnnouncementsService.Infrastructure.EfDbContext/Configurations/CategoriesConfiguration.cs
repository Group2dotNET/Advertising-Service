using AnnouncementsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnnouncementsService.Infrastructure.EfDbContext.Configurations;

internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("categories")
			   .Property(c => c.Id)
			   .HasColumnName("category_id");
		builder.HasKey(c => c.Id).HasName("categories_primary_key");

		builder.Property(c => c.Name)
			.HasColumnName("name");
		builder.HasIndex(c => c.Name)
			.IsUnique()
			.HasDatabaseName("IX_Names_Ascending");

		builder.Property(c => c.ParentCategoryId)
			.HasColumnName("parent_category_id");
		builder.HasOne(c => c.ParentCategory)
			   .WithMany(c => c.ChildCategories)
			   .HasForeignKey(a => a.ParentCategoryId);

		builder.Property(c => c.Characteristics)
			   .HasColumnType("jsonb");
		builder.Property(c => c.Filtres)
			   .HasColumnType("jsonb");
	}
}
