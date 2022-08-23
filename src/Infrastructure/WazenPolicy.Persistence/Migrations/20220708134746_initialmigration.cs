using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenPolicy.Persistence.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArabicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    IBanNum = table.Column<string>(nullable: true),
                    BankIdCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArabicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalIssues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MedicalIssueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalIssues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NationalIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArabicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salutations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salutations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePurpose",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehiclePurposeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePurpose", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ViolationTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ArabicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ICAdditionalCovers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICAdditionalCovers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICAdditionalCovers_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICBankCodes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICBankCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICBankCodes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICCardIdTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICCardIdTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICCardIdTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICCities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICCities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICCities_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICCountries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICCountries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICCountries_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICDeductables",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDeductables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICDeductables_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICDiscounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDiscounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICDiscounts_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICDriverTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDriverTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICDriverTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICDrivingPercentages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDrivingPercentages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICDrivingPercentages_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICEducations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICEducations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICEducations_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICGenders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICGenders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICGenders_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICHealthConditions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICHealthConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICHealthConditions_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICImageTitles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICImageTitles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICImageTitles_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICLicenseTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICLicenseTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICLicenseTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICMaritalStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMaritalStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICMaritalStatus_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICMileages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMileages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICMileages_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICNationalities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICNationalities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICNationalities_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICNCDFreeYears",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICNCDFreeYears", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICNCDFreeYears_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICOccupations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICOccupations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICOccupations_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICParkingLocations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICParkingLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICParkingLocations_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICPaymentMethods",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICPaymentMethods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICPaymentMethods_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICPlateLetters",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICPlateLetters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICPlateLetters_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICPremiumBreakdown",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICPremiumBreakdown", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICPremiumBreakdown_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICPriceTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICPriceTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICPriceTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICProductTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICProductTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICProductTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICRelationships",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICRelationships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICRelationships_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICRepairTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICRepairTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICRepairTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICTransmissionTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICTransmissionTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICTransmissionTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleAxlesWeights",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleAxlesWeights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleAxlesWeights_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleColors",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleColors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleColors_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleEngineSizes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleEngineSizes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleEngineSizes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleIdTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleIdTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleIdTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehiclePlateTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehiclePlateTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehiclePlateTypes_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleSpecifications",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleSpecifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleSpecifications_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICVehicleUses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICVehicleUses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICVehicleUses_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICViolations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICViolations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICViolations_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    idIssuePlace = table.Column<string>(nullable: true),
                    VerifyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_NationalIdTypes_NationalIdTypeId",
                        column: x => x.NationalIdTypeId,
                        principalTable: "NationalIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Salutations_SalutationId",
                        column: x => x.SalutationId,
                        principalTable: "Salutations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    idIssuePlace = table.Column<string>(nullable: true),
                    VerifyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCustomers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempCustomers_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempCustomers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempCustomers_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempCustomers_NationalIdTypes_NationalIdTypeId",
                        column: x => x.NationalIdTypeId,
                        principalTable: "NationalIdTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempCustomers_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempCustomers_Salutations_SalutationId",
                        column: x => x.SalutationId,
                        principalTable: "Salutations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: true),
                    VehiclePlateType = table.Column<string>(nullable: true),
                    VehiclePlateNumber = table.Column<string>(nullable: true),
                    FirstPlateLetter = table.Column<string>(nullable: true),
                    SecondPlateLetter = table.Column<string>(nullable: true),
                    ThirdPlateLetter = table.Column<string>(nullable: true),
                    VehicleModel = table.Column<string>(nullable: true),
                    VehicleMake = table.Column<string>(nullable: true),
                    VehicleColor = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<string>(nullable: true),
                    VehicleRegistrationExpiryDate = table.Column<DateTime>(nullable: false),
                    RegistrationCard = table.Column<string>(nullable: true),
                    SequenceNumberCustomID = table.Column<string>(nullable: true),
                    OwnershipTransfer = table.Column<string>(nullable: true),
                    IncaseofTransfer = table.Column<string>(nullable: true),
                    VehicleUsagePercentage = table.Column<string>(nullable: true),
                    YearofManufacture = table.Column<string>(nullable: true),
                    InsuredIDExpiry = table.Column<string>(nullable: true),
                    VehiclePurposeId = table.Column<int>(nullable: true),
                    VehicleNumber = table.Column<string>(nullable: true),
                    AverageDailyMileage = table.Column<string>(nullable: true),
                    TransferOwnership = table.Column<string>(nullable: true),
                    ParkingGarage = table.Column<bool>(nullable: false),
                    EstimateValue = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclePurpose_VehiclePurposeId",
                        column: x => x.VehiclePurposeId,
                        principalTable: "VehiclePurpose",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempVehicle",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: true),
                    VehiclePlateType = table.Column<string>(nullable: true),
                    VehiclePlateNumber = table.Column<string>(nullable: true),
                    FirstPlateLetter = table.Column<string>(nullable: true),
                    SecondPlateLetter = table.Column<string>(nullable: true),
                    ThirdPlateLetter = table.Column<string>(nullable: true),
                    VehicleModel = table.Column<string>(nullable: true),
                    VehicleMake = table.Column<string>(nullable: true),
                    VehicleColor = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<string>(nullable: true),
                    VehicleRegistrationExpiryDate = table.Column<DateTime>(nullable: false),
                    RegistrationCard = table.Column<string>(nullable: true),
                    SequenceNumberCustomID = table.Column<string>(nullable: true),
                    OwnershipTransfer = table.Column<string>(nullable: true),
                    IncaseofTransfer = table.Column<string>(nullable: true),
                    VehicleUsagePercentage = table.Column<string>(nullable: true),
                    YearofManufacture = table.Column<string>(nullable: true),
                    InsuredIDExpiry = table.Column<string>(nullable: true),
                    VehiclePurposeId = table.Column<int>(nullable: true),
                    VehicleNumber = table.Column<string>(nullable: true),
                    AverageDailyMileage = table.Column<string>(nullable: true),
                    TransferOwnership = table.Column<string>(nullable: true),
                    ParkingGarage = table.Column<bool>(nullable: false),
                    EstimateValue = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempVehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempVehicle_TempCustomers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "TempCustomers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempVehicle_VehiclePurpose_VehiclePurposeId",
                        column: x => x.VehiclePurposeId,
                        principalTable: "VehiclePurpose",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerVehicles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<Guid>(nullable: false),
                    VehicleID = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerVehicles_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerVehicles_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerVehicleId = table.Column<Guid>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Relation = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    EducationId = table.Column<int>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    ChildrenBelow16 = table.Column<string>(nullable: true),
                    WorkCity = table.Column<string>(nullable: true),
                    HomeAddressCity = table.Column<string>(nullable: true),
                    WorkCompanyName = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    TrafficViolations = table.Column<string>(nullable: true),
                    HealthConditions = table.Column<string>(nullable: true),
                    LicenseOwnYears = table.Column<string>(nullable: true),
                    MedicalIssueId = table.Column<int>(nullable: true),
                    IsMainDriver = table.Column<bool>(nullable: false),
                    DNID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Vehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_MedicalIssues_MedicalIssueId",
                        column: x => x.MedicalIssueId,
                        principalTable: "MedicalIssues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleViolations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleID = table.Column<Guid>(nullable: true),
                    ViolationDate = table.Column<DateTime>(nullable: false),
                    ViolationTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleViolations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehicleViolations_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleViolations_ViolationTypes_ViolationTypeId",
                        column: x => x.ViolationTypeId,
                        principalTable: "ViolationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempDrivers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerVehicleId = table.Column<Guid>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Relation = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    EducationId = table.Column<int>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    ChildrenBelow16 = table.Column<string>(nullable: true),
                    WorkCity = table.Column<string>(nullable: true),
                    HomeAddressCity = table.Column<string>(nullable: true),
                    WorkCompanyName = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    TrafficViolations = table.Column<bool>(nullable: false),
                    HealthConditions = table.Column<string>(nullable: true),
                    LicenseOwnYears = table.Column<string>(nullable: true),
                    MedicalIssueId = table.Column<int>(nullable: true),
                    IsMainDriver = table.Column<bool>(nullable: false),
                    DNID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempDrivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempDrivers_TempVehicle_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "TempVehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempDrivers_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempDrivers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempDrivers_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempDrivers_MedicalIssues_MedicalIssueId",
                        column: x => x.MedicalIssueId,
                        principalTable: "MedicalIssues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempDrivers_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempVehicleViolations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleID = table.Column<Guid>(nullable: true),
                    ViolationDate = table.Column<DateTime>(nullable: false),
                    ViolationTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempVehicleViolations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempVehicleViolations_TempVehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "TempVehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempVehicleViolations_ViolationTypes_ViolationTypeId",
                        column: x => x.ViolationTypeId,
                        principalTable: "ViolationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicies",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerVehicleID = table.Column<Guid>(nullable: true),
                    PurchaseService = table.Column<string>(nullable: true),
                    Cancellation = table.Column<string>(nullable: true),
                    ReasonforCancellation = table.Column<string>(nullable: true),
                    ClaimIfAny = table.Column<string>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true),
                    InsuranceType = table.Column<string>(nullable: true),
                    PolicyName = table.Column<string>(nullable: true),
                    PolicyType = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    PolicyNo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    SequenceNo = table.Column<string>(nullable: true),
                    EffectiveCancellationDate = table.Column<DateTime>(nullable: true),
                    LocoftheDamagedVehicle = table.Column<string>(nullable: true),
                    ServicesAddonsTypes = table.Column<string>(nullable: true),
                    ListofAbandonedQuotes = table.Column<string>(nullable: true),
                    RequestDateTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PolicyPriced = table.Column<string>(nullable: true),
                    PolicyAmountPaid = table.Column<string>(nullable: true),
                    CoverNote = table.Column<string>(nullable: true),
                    ImagesUploaded = table.Column<string>(nullable: true),
                    PremiumAmount = table.Column<string>(nullable: true),
                    AdditionalCoverageAmount = table.Column<string>(nullable: true),
                    AdditionalCoverage = table.Column<string>(nullable: true),
                    ServiceChargeAmount = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true),
                    GroundTotal = table.Column<string>(nullable: true),
                    IsUpgraded = table.Column<bool>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_CustomerVehicles_CustomerVehicleID",
                        column: x => x.CustomerVehicleID,
                        principalTable: "CustomerVehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CancellationRequest",
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
                    SwiftCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CancellationRequest_CustomerPolicies_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "CustomerPolicies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancellationRequest_PolicyID",
                table: "CancellationRequest",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerVehicleID",
                table: "CustomerPolicies",
                column: "CustomerVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EducationId",
                table: "Customers",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GenderId",
                table: "Customers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MaritalStatusId",
                table: "Customers",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NationalIdTypeId",
                table: "Customers",
                column: "NationalIdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OccupationId",
                table: "Customers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalutationId",
                table: "Customers",
                column: "SalutationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVehicles_CustomerID",
                table: "CustomerVehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerVehicles_VehicleID",
                table: "CustomerVehicles",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CustomerVehicleId",
                table: "Drivers",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_EducationId",
                table: "Drivers",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_GenderId",
                table: "Drivers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_MaritalStatusId",
                table: "Drivers",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_MedicalIssueId",
                table: "Drivers",
                column: "MedicalIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_OccupationId",
                table: "Drivers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_ICAdditionalCovers_ICID",
                table: "ICAdditionalCovers",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICBankCodes_ICID",
                table: "ICBankCodes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICCardIdTypes_ICID",
                table: "ICCardIdTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICCities_ICID",
                table: "ICCities",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICCountries_ICID",
                table: "ICCountries",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICDeductables_ICID",
                table: "ICDeductables",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICDiscounts_ICID",
                table: "ICDiscounts",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICDriverTypes_ICID",
                table: "ICDriverTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICDrivingPercentages_ICID",
                table: "ICDrivingPercentages",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICEducations_ICID",
                table: "ICEducations",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICGenders_ICID",
                table: "ICGenders",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICHealthConditions_ICID",
                table: "ICHealthConditions",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICImageTitles_ICID",
                table: "ICImageTitles",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICLicenseTypes_ICID",
                table: "ICLicenseTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICMaritalStatus_ICID",
                table: "ICMaritalStatus",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICMileages_ICID",
                table: "ICMileages",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICNationalities_ICID",
                table: "ICNationalities",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICNCDFreeYears_ICID",
                table: "ICNCDFreeYears",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICOccupations_ICID",
                table: "ICOccupations",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICParkingLocations_ICID",
                table: "ICParkingLocations",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICPaymentMethods_ICID",
                table: "ICPaymentMethods",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICPlateLetters_ICID",
                table: "ICPlateLetters",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICPremiumBreakdown_ICID",
                table: "ICPremiumBreakdown",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICPriceTypes_ICID",
                table: "ICPriceTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICProductTypes_ICID",
                table: "ICProductTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICRelationships_ICID",
                table: "ICRelationships",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICRepairTypes_ICID",
                table: "ICRepairTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICTransmissionTypes_ICID",
                table: "ICTransmissionTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleAxlesWeights_ICID",
                table: "ICVehicleAxlesWeights",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleColors_ICID",
                table: "ICVehicleColors",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleEngineSizes_ICID",
                table: "ICVehicleEngineSizes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleIdTypes_ICID",
                table: "ICVehicleIdTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehiclePlateTypes_ICID",
                table: "ICVehiclePlateTypes",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleSpecifications_ICID",
                table: "ICVehicleSpecifications",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICVehicleUses_ICID",
                table: "ICVehicleUses",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_ICViolations_ICID",
                table: "ICViolations",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_EducationId",
                table: "TempCustomers",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_GenderId",
                table: "TempCustomers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_MaritalStatusId",
                table: "TempCustomers",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_NationalIdTypeId",
                table: "TempCustomers",
                column: "NationalIdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_OccupationId",
                table: "TempCustomers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCustomers_SalutationId",
                table: "TempCustomers",
                column: "SalutationId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_CustomerVehicleId",
                table: "TempDrivers",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_EducationId",
                table: "TempDrivers",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_GenderId",
                table: "TempDrivers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_MaritalStatusId",
                table: "TempDrivers",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_MedicalIssueId",
                table: "TempDrivers",
                column: "MedicalIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDrivers_OccupationId",
                table: "TempDrivers",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicle_CustomerID",
                table: "TempVehicle",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicle_VehiclePurposeId",
                table: "TempVehicle",
                column: "VehiclePurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicleViolations_VehicleID",
                table: "TempVehicleViolations",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicleViolations_ViolationTypeId",
                table: "TempVehicleViolations",
                column: "ViolationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerID",
                table: "Vehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehiclePurposeId",
                table: "Vehicles",
                column: "VehiclePurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleViolations_VehicleID",
                table: "VehicleViolations",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleViolations_ViolationTypeId",
                table: "VehicleViolations",
                column: "ViolationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancellationRequest");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "ICAdditionalCovers");

            migrationBuilder.DropTable(
                name: "ICBankCodes");

            migrationBuilder.DropTable(
                name: "ICCardIdTypes");

            migrationBuilder.DropTable(
                name: "ICCities");

            migrationBuilder.DropTable(
                name: "ICCountries");

            migrationBuilder.DropTable(
                name: "ICDeductables");

            migrationBuilder.DropTable(
                name: "ICDiscounts");

            migrationBuilder.DropTable(
                name: "ICDriverTypes");

            migrationBuilder.DropTable(
                name: "ICDrivingPercentages");

            migrationBuilder.DropTable(
                name: "ICEducations");

            migrationBuilder.DropTable(
                name: "ICGenders");

            migrationBuilder.DropTable(
                name: "ICHealthConditions");

            migrationBuilder.DropTable(
                name: "ICImageTitles");

            migrationBuilder.DropTable(
                name: "ICLicenseTypes");

            migrationBuilder.DropTable(
                name: "ICMaritalStatus");

            migrationBuilder.DropTable(
                name: "ICMileages");

            migrationBuilder.DropTable(
                name: "ICNationalities");

            migrationBuilder.DropTable(
                name: "ICNCDFreeYears");

            migrationBuilder.DropTable(
                name: "ICOccupations");

            migrationBuilder.DropTable(
                name: "ICParkingLocations");

            migrationBuilder.DropTable(
                name: "ICPaymentMethods");

            migrationBuilder.DropTable(
                name: "ICPlateLetters");

            migrationBuilder.DropTable(
                name: "ICPremiumBreakdown");

            migrationBuilder.DropTable(
                name: "ICPriceTypes");

            migrationBuilder.DropTable(
                name: "ICProductTypes");

            migrationBuilder.DropTable(
                name: "ICRelationships");

            migrationBuilder.DropTable(
                name: "ICRepairTypes");

            migrationBuilder.DropTable(
                name: "ICTransmissionTypes");

            migrationBuilder.DropTable(
                name: "ICVehicleAxlesWeights");

            migrationBuilder.DropTable(
                name: "ICVehicleColors");

            migrationBuilder.DropTable(
                name: "ICVehicleEngineSizes");

            migrationBuilder.DropTable(
                name: "ICVehicleIdTypes");

            migrationBuilder.DropTable(
                name: "ICVehiclePlateTypes");

            migrationBuilder.DropTable(
                name: "ICVehicleSpecifications");

            migrationBuilder.DropTable(
                name: "ICVehicleUses");

            migrationBuilder.DropTable(
                name: "ICViolations");

            migrationBuilder.DropTable(
                name: "TempDrivers");

            migrationBuilder.DropTable(
                name: "TempVehicleViolations");

            migrationBuilder.DropTable(
                name: "VehicleViolations");

            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "MedicalIssues");

            migrationBuilder.DropTable(
                name: "TempVehicle");

            migrationBuilder.DropTable(
                name: "ViolationTypes");

            migrationBuilder.DropTable(
                name: "CustomerVehicles");

            migrationBuilder.DropTable(
                name: "TempCustomers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "VehiclePurpose");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "NationalIdTypes");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Salutations");
        }
    }
}
