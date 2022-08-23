using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class violationTempViolationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempVehicleViolations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleID = table.Column<Guid>(nullable: false),
                    ViolationDate = table.Column<DateTime>(nullable: false),
                    ViolationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempVehicleViolations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempVehicleViolations_TempVehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "TempVehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleViolations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleID = table.Column<Guid>(nullable: false),
                    ViolationDate = table.Column<DateTime>(nullable: false),
                    ViolationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleViolations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehicleViolations_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicleViolations_VehicleID",
                table: "TempVehicleViolations",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleViolations_VehicleID",
                table: "VehicleViolations",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempVehicleViolations");

            migrationBuilder.DropTable(
                name: "VehicleViolations");
        }
    }
}
