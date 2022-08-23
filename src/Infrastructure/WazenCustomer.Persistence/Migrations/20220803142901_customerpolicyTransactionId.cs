using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerpolicyTransactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPolicies_Transactions_TransactionId",
                table: "CustomerPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPolicies_TransactionId",
                table: "CustomerPolicies");
        }
    }
}
