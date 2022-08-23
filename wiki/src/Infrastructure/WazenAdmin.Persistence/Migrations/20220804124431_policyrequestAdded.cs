using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class policyrequestAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyRequests",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    InsurancePolicy_ProductName = table.Column<string>(nullable: true),
                    NationalityID = table.Column<int>(nullable: false),
                    PolicyEffectiveDate = table.Column<DateTime>(nullable: false),
                    PolicyDuration = table.Column<string>(nullable: true),
                    PolicyAmount = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRequests", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyRequests");
        }
    }
}
