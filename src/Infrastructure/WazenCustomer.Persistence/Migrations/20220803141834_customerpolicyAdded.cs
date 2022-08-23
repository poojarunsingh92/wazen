using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerpolicyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalCoverageAmount",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GroundTotal",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpgraded",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PolicyRequestRefNo",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PolicyResponse",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyTypeId",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PremiumAmount",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceChargeAmount",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "VAT",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalCoverageAmount",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "GroundTotal",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "IsUpgraded",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyRequestRefNo",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyResponse",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PolicyTypeId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "PremiumAmount",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "ServiceChargeAmount",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "CustomerPolicies");
        }
    }
}
