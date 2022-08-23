using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class customerpolicyChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "CustomerPolicies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: true),
                    VehiclePlateType = table.Column<string>(nullable: true),
                    VehiclePlateNumber = table.Column<string>(nullable: true),
                    FirstPlateLetter = table.Column<string>(nullable: true),
                    SecondPlateLetter = table.Column<string>(nullable: true),
                    ThirdPlateLetter = table.Column<string>(nullable: true),
                    VehicleModel = table.Column<string>(nullable: true),
                    VehicleMake = table.Column<string>(nullable: true),
                    VehicleColor = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<string>(nullable: true),
                    VehicleRegistrationExpiryDate = table.Column<DateTime>(nullable: false),
                    RegistrationCard = table.Column<string>(nullable: true),
                    SequenceNumberCustomID = table.Column<string>(nullable: true),
                    OwnershipTransfer = table.Column<string>(nullable: true),
                    IncaseofTransfer = table.Column<string>(nullable: true),
                    VehicleUsagePercentage = table.Column<string>(nullable: true),
                    YearofManufacture = table.Column<string>(nullable: true),
                    InsuredIDExpiry = table.Column<string>(nullable: true),
                    VehiclePurposeId = table.Column<int>(nullable: true),
                    VehicleNumber = table.Column<string>(nullable: true),
                    AverageDailyMileage = table.Column<string>(nullable: true),
                    TransferOwnership = table.Column<string>(nullable: true),
                    ParkingGarage = table.Column<string>(nullable: true),
                    EstimateValue = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerId",
                table: "CustomerPolicies",
                column: "CustomerId");

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
                name: "FK_CustomerPolicies_Vehicle_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Customers_CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Vehicle_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "CustomerPolicies");
        }
    }
}
