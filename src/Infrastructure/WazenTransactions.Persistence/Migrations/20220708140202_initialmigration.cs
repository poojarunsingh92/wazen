using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    IBanNum = table.Column<string>(nullable: true),
                    BankIdCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationalIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    EnglishFirstName = table.Column<string>(nullable: true),
                    EnglishMiddleName = table.Column<string>(nullable: true),
                    EnglishLastName = table.Column<string>(nullable: true),
                    ArabicFirstName = table.Column<string>(nullable: true),
                    ArabicMiddleName = table.Column<string>(nullable: true),
                    ArabicLastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    NIN = table.Column<string>(nullable: true),
                    NationalIdTypeId = table.Column<int>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_NationalIdTypes_NationalIdTypeId",
                        column: x => x.NationalIdTypeId,
                        principalTable: "NationalIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleRegistrationNumber = table.Column<string>(nullable: true),
                    VehicleRegistrationExpiryDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerVehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    StatusDsc = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionType = table.Column<string>(nullable: true),
                    PaymentGatewayResponse = table.Column<string>(nullable: true),
                    IcAmount = table.Column<decimal>(nullable: false),
                    WpAmount = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    ICId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    CustomerVehicleId = table.Column<Guid>(nullable: true),
                    TransactionId = table.Column<Guid>(nullable: true),
                    PolicyTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    PolicyResponse = table.Column<string>(nullable: true),
                    PremiumDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_CustomerVehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "CustomerVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicyAdditionalCoverages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerPolicyId = table.Column<Guid>(nullable: true),
                    AdditionalCoverage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicyAdditionalCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPolicyAdditionalCoverages_CustomerPolicies_CustomerPolicyId",
                        column: x => x.CustomerPolicyId,
                        principalTable: "CustomerPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_TransactionId",
                table: "CustomerPolicies",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicyAdditionalCoverages_CustomerPolicyId",
                table: "CustomerPolicyAdditionalCoverages",
                column: "CustomerPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NationalIdTypeId",
                table: "Customers",
                column: "NationalIdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVehicles_CustomerId",
                table: "CustomerVehicles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPolicyAdditionalCoverages");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "CustomerVehicles");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "NationalIdTypes");
        }
    }
}
