using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class customerPolicyTransactionIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "CustomerPolicies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_TransactionId",
                table: "CustomerPolicies",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPolicies_Transactions_TransactionId",
                table: "CustomerPolicies",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Transactions_TransactionId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_TransactionId",
                table: "CustomerPolicies");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "CustomerPolicies");
        }
    }
}
