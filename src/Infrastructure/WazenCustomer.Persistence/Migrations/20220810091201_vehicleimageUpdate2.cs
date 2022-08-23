using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class vehicleimageUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleID",
                table: "VehicleImages",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleImages_Vehicles_VehicleID",
                table: "VehicleImages",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleImages_Vehicles_VehicleID",
                table: "VehicleImages");

            migrationBuilder.DropIndex(
                name: "IX_VehicleImages_VehicleID",
                table: "VehicleImages");
        }
    }
}
