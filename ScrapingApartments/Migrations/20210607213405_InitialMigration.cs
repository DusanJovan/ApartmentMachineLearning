using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ScrapingApartments.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    link = table.Column<string>(type: "text", nullable: true),
                    apartment_type = table.Column<int>(type: "integer", nullable: false),
                    action_type = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    apartment_area = table.Column<double>(type: "double precision", nullable: true),
                    yard_area = table.Column<double>(type: "double precision", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    micro_location = table.Column<string>(type: "text", nullable: true),
                    room_count = table.Column<double>(type: "double precision", nullable: true),
                    story = table.Column<string>(type: "text", nullable: true),
                    story_total = table.Column<string>(type: "text", nullable: true),
                    heat_type = table.Column<string>(type: "text", nullable: true),
                    registered = table.Column<bool>(type: "boolean", nullable: false),
                    parking = table.Column<bool>(type: "boolean", nullable: false),
                    elevator = table.Column<bool>(type: "boolean", nullable: false),
                    terrace = table.Column<bool>(type: "boolean", nullable: false),
                    balcony = table.Column<bool>(type: "boolean", nullable: false),
                    loggia = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apartments");
        }
    }
}
