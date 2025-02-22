using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnouncementsService.Infrastructure.EfDbContext.Migrations
{
    /// <inheritdoc />
    public partial class UserTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "announcements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "announcements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
