using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnnouncementsService.Infrastructure.EfDbContext.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_Categories_category_id",
                table: "announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "categories",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "categories",
                newName: "parent_category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "categories",
                newName: "IX_categories_parent_category_id");

            migrationBuilder.AddPrimaryKey(
                name: "categories_primary_key",
                table: "categories",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_categories_category_id",
                table: "announcements",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_parent_category_id",
                table: "categories",
                column: "parent_category_id",
                principalTable: "categories",
                principalColumn: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcements_categories_category_id",
                table: "announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_parent_category_id",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "categories_primary_key",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "parent_category_id",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_categories_parent_category_id",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_announcements_Categories_category_id",
                table: "announcements",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
