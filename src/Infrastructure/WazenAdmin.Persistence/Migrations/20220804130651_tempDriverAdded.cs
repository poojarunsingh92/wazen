using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class tempDriverAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempDrivers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerVehicleId = table.Column<Guid>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Relation = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    EducationId = table.Column<int>(nullable: false),
                    OccupationId = table.Column<int>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    ChildrenBelow16 = table.Column<string>(nullable: true),
                    WorkCity = table.Column<string>(nullable: true),
                    HomeAddressCity = table.Column<string>(nullable: true),
                    WorkCompanyName = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    TrafficViolations = table.Column<bool>(nullable: false),
                    HealthConditions = table.Column<string>(nullable: true),
                    LicenseOwnYears = table.Column<string>(nullable: true),
                    MedicalIssueId = table.Column<int>(nullable: true),
                    IsMainDriver = table.Column<bool>(nullable: false),
                    DNID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempDrivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempDrivers_TempVehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "TempVehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_CustomerVehicleId",
                table: "TempDrivers",
                column: "CustomerVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempDrivers");
        }
    }
}
