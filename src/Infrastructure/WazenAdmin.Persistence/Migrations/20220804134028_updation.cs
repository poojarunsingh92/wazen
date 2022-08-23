using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class updation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleType",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleType",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "Userid",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerifyCode",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerifyCode",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleType",
                table: "Users",
                column: "RoleType");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleType",
                table: "Users",
                column: "RoleType",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
