using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerPolicyTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PolicyTypeId",
                table: "CustomerPolicies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PolicyTypeId",
                table: "CustomerPolicies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
