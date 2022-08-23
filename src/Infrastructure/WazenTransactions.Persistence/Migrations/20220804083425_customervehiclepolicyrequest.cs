using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class customervehiclepolicyrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Vehicle_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AverageDailyMileage",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "EstimateValue",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FirstPlateLetter",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IncaseofTransfer",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "InsuredIDExpiry",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "OwnershipTransfer",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ParkingGarage",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RegistrationCard",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RegistrationType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SecondPlateLetter",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SequenceNumberCustomID",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ThirdPlateLetter",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TransferOwnership",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleColor",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehiclePlateNumber",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehiclePlateType",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehiclePurposeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleUsagePercentage",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "YearofManufacture",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PolicyRequests",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    InsurancePolicy_ProductName = table.Column<string>(nullable: true),
                    NationalityID = table.Column<int>(nullable: false),
                    PolicyEffectiveDate = table.Column<DateTime>(nullable: false),
                    PolicyDuration = table.Column<string>(nullable: true),
                    PolicyAmount = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PolicyRequests_NationalIdTypes_NationalityID",
                        column: x => x.NationalityID,
                        principalTable: "NationalIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerID",
                table: "Vehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRequests_NationalityID",
                table: "PolicyRequests",
                column: "NationalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Vehicles_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Customers_CustomerID",
                table: "Vehicles",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Vehicles_VehicleId",
                table: "CustomerPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Customers_CustomerID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "PolicyRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CustomerID",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "AverageDailyMileage",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimateValue",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstPlateLetter",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncaseofTransfer",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuredIDExpiry",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OwnershipTransfer",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParkingGarage",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationCard",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPlateLetter",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SequenceNumber",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SequenceNumberCustomID",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdPlateLetter",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferOwnership",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehiclePlateNumber",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehiclePlateType",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehiclePurposeId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleUsagePercentage",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearofManufacture",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Vehicle_VehicleId",
                table: "CustomerPolicies",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
