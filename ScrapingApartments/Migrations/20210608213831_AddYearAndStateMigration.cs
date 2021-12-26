using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrapingApartments.Migrations
{
    public partial class AddYearAndStateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "state_type",
                table: "apartments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year_type",
                table: "apartments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state_type",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "year_type",
                table: "apartments");
        }
    }
}
