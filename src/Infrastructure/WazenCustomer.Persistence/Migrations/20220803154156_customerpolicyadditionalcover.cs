using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class customerpolicyadditionalcover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerPolicyId",
                table: "CustomerPolicyAdditionalCoverages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerPolicyId",
                table: "CustomerPolicyAdditionalCoverages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
