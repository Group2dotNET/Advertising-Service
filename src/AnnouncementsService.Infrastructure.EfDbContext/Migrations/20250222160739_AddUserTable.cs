using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnouncementsService.Infrastructure.EfDbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "announcements",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "announcements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    external_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_primary_key", x => x.user_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_announcements_OwnerId",
                table: "announcements",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Ascending",
                table: "users",
                column: "login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_users_OwnerId",
                table: "announcements",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_users_OwnerId",
                table: "announcements");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_announcements_OwnerId",
                table: "announcements");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "announcements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "announcements");
        }
    }
}
