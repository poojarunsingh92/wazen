using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class customerpolicyCustomerVehicleIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_CustomerVehicles_CustomerVehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "CustomerVehicleId",
                table: "CustomerPolicies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerVehicleId",
                table: "CustomerPolicies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_CustomerVehicles_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId",
                principalTable: "CustomerVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
