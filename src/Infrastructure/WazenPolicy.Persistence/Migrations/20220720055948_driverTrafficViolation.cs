using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenPolicy.Persistence.Migrations
{
    public partial class driverTrafficViolation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrafficViolations",
                table: "Drivers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrafficViolations",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
