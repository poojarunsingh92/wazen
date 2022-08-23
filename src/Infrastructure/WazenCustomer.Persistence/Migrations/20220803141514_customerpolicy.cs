using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerpolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Vehicles_CustomerVehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_InsuranceCompanies_ICID",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_ICID",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "CustomerVehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "ICID",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "IssuedDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PremiumDetails",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CustomerPolicies");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CustomerPolicies",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CustomerPolicies",
                newName: "ID");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerVehicleId",
                table: "CustomerPolicies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "CustomerPolicies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ICID",
                table: "CustomerPolicies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedDate",
                table: "CustomerPolicies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "CustomerPolicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyTypeId",
                table: "CustomerPolicies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiumDetails",
                table: "CustomerPolicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CustomerPolicies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CustomerPolicies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "CustomerPolicies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_ICID",
                table: "CustomerPolicies",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Vehicles_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_InsuranceCompanies_ICID",
                table: "CustomerPolicies",
                column: "ICID",
                principalTable: "InsuranceCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId",
                principalTable: "PolicyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
