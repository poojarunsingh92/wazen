using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerpolicyAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerId",
                table: "CustomerPolicies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Customers_CustomerId",
                table: "CustomerPolicies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId",
                principalTable: "PolicyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Vehicles_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Customers_CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Vehicles_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies");
        }
    }
}
