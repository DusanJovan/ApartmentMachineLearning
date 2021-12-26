using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrapingApartments.Migrations
{
    public partial class NewNesto3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "average_state_price",
                table: "apartments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "average_state_price",
                table: "apartments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
