using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnouncementsService.Infrastructure.EfDbContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategories_CreateIndexName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Names_Ascending",
                table: "categories",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Names_Ascending",
                table: "categories");
        }
    }
}
