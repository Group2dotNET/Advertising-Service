using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnouncementsService.Infrastructure.EfDbContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategories_CharacteristicsAndFiltres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "Characteristics",
                table: "categories",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Filtres",
                table: "categories",
                type: "jsonb",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characteristics",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Filtres",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "categories",
                type: "text",
                nullable: true);
        }
    }
}
