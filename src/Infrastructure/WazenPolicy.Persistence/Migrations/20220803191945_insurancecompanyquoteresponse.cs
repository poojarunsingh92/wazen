using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenPolicy.Persistence.Migrations
{
    public partial class insurancecompanyquoteresponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCompanyQuoteResponses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    QuoteRequestID = table.Column<string>(nullable: true),
                    LiabilityOfDetermination = table.Column<string>(nullable: true),
                    QuotationPrice = table.Column<string>(nullable: true),
                    QuoteExpiryTimer = table.Column<DateTime>(nullable: false),
                    Deduction = table.Column<string>(nullable: true),
                    AddAddionalCoverage = table.Column<string>(nullable: true),
                    QuoteResponses = table.Column<string>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: false),
                    InsuranceType = table.Column<string>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanyQuoteResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InsuranceCompanyQuoteResponses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCompanyQuoteResponses_CustomerID",
                table: "InsuranceCompanyQuoteResponses",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCompanyQuoteResponses");
        }
    }
}
