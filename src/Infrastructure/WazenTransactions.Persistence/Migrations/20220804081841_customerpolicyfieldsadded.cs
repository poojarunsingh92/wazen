using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class customerpolicyfieldsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalCoverageAmount",
                table: "CustomerPolicies",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "PremiumAmount",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceChargeAmount",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VAT",
                table: "CustomerPolicies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalCoverageAmount",
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
                name: "PremiumAmount",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "ServiceChargeAmount",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "CustomerPolicies");
        }
    }
}
