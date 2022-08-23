using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class tempCustomerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempCustomers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    SalutationId = table.Column<int>(nullable: true),
                    EnglishFirstName = table.Column<string>(nullable: true),
                    EnglishMiddleName = table.Column<string>(nullable: true),
                    EnglishLastName = table.Column<string>(nullable: true),
                    ArabicFirstName = table.Column<string>(nullable: true),
                    ArabicMiddleName = table.Column<string>(nullable: true),
                    ArabicLastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NationalIdTypeId = table.Column<int>(nullable: true),
                    NIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<int>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    EducationId = table.Column<int>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
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
                    idIssuePlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCustomers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempCustomers");
        }
    }
}
