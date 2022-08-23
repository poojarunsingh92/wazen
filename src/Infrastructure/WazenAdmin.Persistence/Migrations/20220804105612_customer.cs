using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID",
                table: "Complaints",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    SalutationId = table.Column<int>(nullable: false),
                    EnglishFirstName = table.Column<string>(nullable: true),
                    EnglishMiddleName = table.Column<string>(nullable: true),
                    EnglishLastName = table.Column<string>(nullable: true),
                    ArabicFirstName = table.Column<string>(nullable: true),
                    ArabicMiddleName = table.Column<string>(nullable: true),
                    ArabicLastName = table.Column<string>(nullable: true),
                    NationalIdTypeId = table.Column<int>(nullable: false),
                    NIN = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    OccupationId = table.Column<int>(nullable: false),
                    EducationId = table.Column<int>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    NewsLetterSubscription = table.Column<bool>(nullable: false),
                    grandFatherName = table.Column<string>(nullable: true),
                    subtribeName = table.Column<string>(nullable: true),
                    familyName = table.Column<string>(nullable: true),
                    EnglishSecondName = table.Column<string>(nullable: true),
                    EnglishThirdName = table.Column<string>(nullable: true),
                    dateOfBirthH = table.Column<string>(nullable: true),
                    licenseList11 = table.Column<string>(nullable: true),
                    idExpiryDate = table.Column<string>(nullable: true),
                    occupationCode = table.Column<string>(nullable: true),
                    YakeenLogId = table.Column<string>(nullable: true),
                    idIssuePlace = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CustomerID",
                table: "Complaints",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Customers_CustomerID",
                table: "Complaints",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Customers_CustomerID",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_CustomerID",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Complaints");
        }
    }
}
