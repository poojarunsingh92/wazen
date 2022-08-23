using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class vehicleimageUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleImages_TempVehicles_VehicleID",
                table: "VehicleImages");

            migrationBuilder.DropIndex(
                name: "IX_VehicleImages_VehicleID",
                table: "VehicleImages");

            /*migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId",
                unique: true);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies");*/

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleID",
                table: "VehicleImages",
                column: "VehicleID");

            /*migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId");*/

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleImages_TempVehicles_VehicleID",
                table: "VehicleImages",
                column: "VehicleID",
                principalTable: "TempVehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
