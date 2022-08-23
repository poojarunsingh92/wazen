using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenCustomer.Persistence.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerOTPs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VerifyCode = table.Column<int>(nullable: false),
                    NIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOTPs", x => x.ID);
                });

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
                name: "PolicyTypes",
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
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
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
                name: "VehiclePurposes",
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
                    table.PrimaryKey("PK_VehiclePurposes", x => x.ID);
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
                    VerifyCode = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false)
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
                        name: "FK_Vehicles_VehiclePurposes_VehiclePurposeId",
                        column: x => x.VehiclePurposeId,
                        principalTable: "VehiclePurposes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempVehicles",
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
                    table.PrimaryKey("PK_TempVehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TempVehicles_TempCustomers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "TempCustomers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TempVehicles_VehiclePurposes_VehiclePurposeId",
                        column: x => x.VehiclePurposeId,
                        principalTable: "VehiclePurposes",
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
                    CustomerVehicleId = table.Column<Guid>(nullable: true),
                    TransactionId = table.Column<Guid>(nullable: false),
                    ICID = table.Column<Guid>(nullable: true),
                    PolicyTypeId = table.Column<int>(nullable: true),
                    PremiumDetails = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_Vehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPolicies_PolicyTypes_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "PolicyTypes",
                        principalColumn: "Id",
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
                    TrafficViolations = table.Column<bool>(nullable: false),
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
                        name: "FK_TempDrivers_TempVehicles_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "TempVehicles",
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
                        name: "FK_TempVehicleViolations_TempVehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "TempVehicles",
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
                name: "VehicleImages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    VehicleID = table.Column<Guid>(nullable: false),
                    VehicleImages = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehicleImages_TempVehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "TempVehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CancellationRequests",
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
                    SwiftCode = table.Column<string>(nullable: true),
                    CustomerPolicyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CancellationRequests_CustomerPolicies_CustomerPolicyId",
                        column: x => x.CustomerPolicyId,
                        principalTable: "CustomerPolicies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPolicyAdditionalCoverages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerPolicyId = table.Column<Guid>(nullable: true),
                    AdditionalCoverage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPolicyAdditionalCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPolicyAdditionalCoverages_CustomerPolicies_CustomerPolicyId",
                        column: x => x.CustomerPolicyId,
                        principalTable: "CustomerPolicies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancellationRequests_CustomerPolicyId",
                table: "CancellationRequests",
                column: "CustomerPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_CustomerVehicleId",
                table: "CustomerPolicies",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_ICID",
                table: "CustomerPolicies",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicies_PolicyTypeId",
                table: "CustomerPolicies",
                column: "PolicyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPolicyAdditionalCoverages_CustomerPolicyId",
                table: "CustomerPolicyAdditionalCoverages",
                column: "CustomerPolicyId");

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
                name: "IX_TempVehicles_CustomerID",
                table: "TempVehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TempVehicles_VehiclePurposeId",
                table: "TempVehicles",
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
                name: "IX_VehicleImages_VehicleID",
                table: "VehicleImages",
                column: "VehicleID");

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
                name: "CancellationRequests");

            migrationBuilder.DropTable(
                name: "CustomerOTPs");

            migrationBuilder.DropTable(
                name: "CustomerPolicyAdditionalCoverages");

            migrationBuilder.DropTable(
                name: "CustomerVehicles");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "TempDrivers");

            migrationBuilder.DropTable(
                name: "TempVehicleViolations");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "VehicleViolations");

            migrationBuilder.DropTable(
                name: "CustomerPolicies");

            migrationBuilder.DropTable(
                name: "MedicalIssues");

            migrationBuilder.DropTable(
                name: "TempVehicles");

            migrationBuilder.DropTable(
                name: "ViolationTypes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropTable(
                name: "TempCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "VehiclePurposes");

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
