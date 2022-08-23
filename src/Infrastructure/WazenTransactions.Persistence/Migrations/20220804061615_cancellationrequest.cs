using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class cancellationrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancellationRequests",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    SequenceNo = table.Column<string>(nullable: true),
                    PolicyID = table.Column<Guid>(nullable: false),
                    CancellationDate = table.Column<DateTime>(nullable: false),
                    ReasonforCancellation = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    IBANNumber = table.Column<string>(nullable: true),
                    SwiftCode = table.Column<string>(nullable: true),
                    CustomerPolicyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CancellationRequests_CustomerPolicies_CustomerPolicyId",
                        column: x => x.CustomerPolicyId,
                        principalTable: "CustomerPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancellationRequests_CustomerPolicyId",
                table: "CancellationRequests",
                column: "CustomerPolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancellationRequests");
        }
    }
}
