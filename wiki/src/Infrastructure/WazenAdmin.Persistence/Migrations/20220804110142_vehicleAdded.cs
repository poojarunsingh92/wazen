using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class vehicleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
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
                    ParkingGarage = table.Column<bool>(nullable: false),
                    EstimateValue = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclePurposes_VehiclePurposeId",
                        column: x => x.VehiclePurposeId,
                        principalTable: "VehiclePurposes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerID",
                table: "Vehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehiclePurposeId",
                table: "Vehicles",
                column: "VehiclePurposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
