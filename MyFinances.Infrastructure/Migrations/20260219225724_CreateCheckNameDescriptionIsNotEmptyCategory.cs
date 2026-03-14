using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCheckNameDescriptionIsNotEmptyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_description_categories",
                table: "categories",
                sql: "Description <> N''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_name_categories",
                table: "categories",
                sql: "Name <> N''");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_description_categories",
                table: "categories");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_name_categories",
                table: "categories");
        }
    }
}
