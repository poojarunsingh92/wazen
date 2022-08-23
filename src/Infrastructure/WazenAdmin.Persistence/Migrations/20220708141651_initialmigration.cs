using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WazenAdmin.Persistence.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerEmailID = table.Column<string>(nullable: true),
                    ComplaintType = table.Column<string>(nullable: true),
                    ComplaintPriority = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    ComplaintMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    NameOfTheCompany = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    LinkedIn = table.Column<string>(nullable: true),
                    WebsiteLink = table.Column<string>(nullable: true),
                    GoogleLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    DisplayOnHome = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HomePageBanners",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageBanners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    NameoftheIC = table.Column<string>(nullable: true),
                    NameofICAdmin = table.Column<string>(nullable: true),
                    ICAdminEmailAddress = table.Column<string>(nullable: true),
                    ICAdminPassword = table.Column<string>(nullable: true),
                    ICAdminPhoneNumber = table.Column<string>(nullable: true),
                    StartDateofCollaboration = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    OfficeNumber = table.Column<string>(nullable: true),
                    Agreements = table.Column<string>(nullable: true),
                    NoofPolicies = table.Column<string>(nullable: true),
                    ConfigurableParameters = table.Column<string>(nullable: true),
                    IsAdminExpenseForNAJM = table.Column<string>(nullable: true),
                    AdminExpenseForNAJM = table.Column<string>(nullable: true),
                    IsAdminExpenseForELM = table.Column<string>(nullable: true),
                    AdminExpenseForELM = table.Column<string>(nullable: true),
                    IsBankFees = table.Column<string>(nullable: true),
                    BankFees = table.Column<string>(nullable: true),
                    IsDefaultExpenses = table.Column<string>(nullable: true),
                    DefaultExpenses = table.Column<string>(nullable: true),
                    IsSharingPercentageForCancellation = table.Column<string>(nullable: true),
                    SharingPercentageForCancellation = table.Column<string>(nullable: true),
                    IsSharingPercentageForAdministrationFees = table.Column<string>(nullable: true),
                    SharingPercentageForAdministrationFees = table.Column<string>(nullable: true),
                    IsCommissionAgreed = table.Column<string>(nullable: true),
                    CommissionAgreed = table.Column<string>(nullable: true),
                    APIAvailable = table.Column<string>(nullable: true),
                    EndpointURL = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CancelAPIAvailable = table.Column<string>(nullable: true),
                    CancelEndpointURL = table.Column<string>(nullable: true),
                    CancelRequestType = table.Column<string>(nullable: true),
                    CancelHeader = table.Column<string>(nullable: true),
                    CancelBody = table.Column<string>(nullable: true),
                    RefundEndpointURL = table.Column<string>(nullable: true),
                    RefundRequestType = table.Column<string>(nullable: true),
                    RefundHeader = table.Column<string>(nullable: true),
                    RefundBody = table.Column<string>(nullable: true),
                    AddOnsRemoveEndpointURL = table.Column<string>(nullable: true),
                    AddOnsRemoveRequestType = table.Column<string>(nullable: true),
                    AddOnsRemoveHeader = table.Column<string>(nullable: true),
                    AddOnsRemoveBody = table.Column<string>(nullable: true),
                    AddOnsRemovePolicyPricing = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    adminExpenseForNAJMType = table.Column<string>(nullable: true),
                    adminExpenseForELMType = table.Column<string>(nullable: true),
                    bankFeesType = table.Column<string>(nullable: true),
                    defaultExpensesType = table.Column<string>(nullable: true),
                    sharingPercentageForCancellationType = table.Column<string>(nullable: true),
                    sharingPercentageForAdministrationFeesType = table.Column<string>(nullable: true),
                    commissionAgreedType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    NotficationTitle = table.Column<string>(nullable: true),
                    TypeofNotification = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    NotificationSentDate = table.Column<DateTime>(nullable: false),
                    EntityType = table.Column<string>(nullable: true),
                    ContentoftheNotificationInEnglish = table.Column<string>(nullable: true),
                    ContentoftheNotificationInArabic = table.Column<string>(nullable: true),
                    TypeOfProduct = table.Column<string>(nullable: true),
                    Events = table.Column<string>(nullable: true),
                    TriggerNotificationAt = table.Column<DateTime>(nullable: false),
                    RecurringTillDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    RoleArabicName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaticContents",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    AboutUs = table.Column<string>(nullable: true),
                    TermsAndCondition = table.Column<string>(nullable: true),
                    PartnerName = table.Column<string>(nullable: true),
                    PartnerLogo = table.Column<string>(nullable: true),
                    RedirectedURL = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    NameOfTheCompany = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    SocialMediaIcon = table.Column<string>(nullable: true),
                    SocialMediaLink = table.Column<string>(nullable: true),
                    WebsiteLink = table.Column<string>(nullable: true),
                    GoogleLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticContents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
                    Heading = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ICAPIDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    ICID = table.Column<Guid>(nullable: false),
                    EndPointURL = table.Column<string>(nullable: true),
                    RequestType = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    APIType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICAPIDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ICAPIDetails_InsuranceCompanies_ICID",
                        column: x => x.ICID,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RoleType = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleType",
                        column: x => x.RoleType,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ICAPIDetails_ICID",
                table: "ICAPIDetails",
                column: "ICID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleType",
                table: "Users",
                column: "RoleType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "HomePageBanners");

            migrationBuilder.DropTable(
                name: "ICAPIDetails");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "StaticContents");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
