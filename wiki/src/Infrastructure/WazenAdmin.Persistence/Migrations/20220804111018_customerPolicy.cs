using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class customerPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    PolicyRequestRefNo = table.Column<string>(nullable: true),
                    VehicleId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    PolicyTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    PolicyResponse = table.Column<string>(nullable: true),
                    ServiceChargeAmount = table.Column<string>(nullable: true),
                    AdditionalCoverageAmount = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true),
                    PremiumAmount = table.Column<string>(nullable: true),
                    GroundTotal = table.Column<string>(nullable: true),
                    IsUpgraded = table.Column<bool>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPolicies");
        }
    }
}
