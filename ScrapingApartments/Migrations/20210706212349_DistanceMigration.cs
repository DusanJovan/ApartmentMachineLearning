using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrapingApartments.Migrations
{
    public partial class DistanceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "distance_from_centre",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "distance_from_centre",
                table: "apartments");
        }
    }
}
