using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenPolicy.Persistence.Migrations
{
    public partial class driverTrafficViolationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TrafficViolations",
                table: "Drivers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrafficViolations",
                table: "Drivers");
        }
    }
}
