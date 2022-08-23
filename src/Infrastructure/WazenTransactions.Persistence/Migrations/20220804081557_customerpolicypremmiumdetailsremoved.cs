using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenTransactions.Persistence.Migrations
{
    public partial class customerpolicypremmiumdetailsremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumDetails",
                table: "CustomerPolicies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PremiumDetails",
                table: "CustomerPolicies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
