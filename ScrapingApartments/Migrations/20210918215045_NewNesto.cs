using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrapingApartments.Migrations
{
    public partial class NewNesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "average_heat_price",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "average_micro_location_price",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "average_state_price",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "average_year_price",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "has_terace_or_loggia_or_balcony",
                table: "apartments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_last_story",
                table: "apartments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "average_heat_price",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "average_micro_location_price",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "average_state_price",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "average_year_price",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "has_terace_or_loggia_or_balcony",
                table: "apartments");

            migrationBuilder.DropColumn(
                name: "is_last_story",
                table: "apartments");
        }
    }
}
