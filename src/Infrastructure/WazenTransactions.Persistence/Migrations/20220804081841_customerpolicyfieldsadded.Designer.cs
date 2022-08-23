﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WazenTransactions.Persistence;

namespace WazenTransactions.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220804081841_customerpolicyfieldsadded")]
    partial class customerpolicyfieldsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CancellationRequest", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CancellationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerPolicyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IBANNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PolicyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonforCancellation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequenceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwiftCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerPolicyId");

                    b.ToTable("CancellationRequests");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArabicFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArabicMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationalIdTypeId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("NationalIdTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerPolicy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalCoverageAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroundTotal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUpgraded")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyRequestRefNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyResponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolicyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PremiumAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceChargeAmount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VAT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PolicyTypeId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("VehicleId");

                    b.ToTable("CustomerPolicies");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerPolicyAdditionalCoverage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdditionalCoverage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerPolicyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerPolicyId");

                    b.ToTable("CustomerPolicyAdditionalCoverages");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VehicleRegistrationExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerVehicles");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.InsuranceCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankIdCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeneficiaryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IBanNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceCompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.NationalIdType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NationalIdTypes");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.PolicyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PolicyTypes");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ICId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("IcAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentGatewayResponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusDsc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WpAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AverageDailyMileage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EstimateValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPlateLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncaseofTransfer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuredIDExpiry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnershipTransfer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParkingGarage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondPlateLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SequenceNumberCustomID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPlateLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferOwnership")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleMake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehiclePlateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehiclePlateType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehiclePurposeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VehicleRegistrationExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleUsagePercentage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearofManufacture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CancellationRequest", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.CustomerPolicy", "CustomerPolicy")
                        .WithMany()
                        .HasForeignKey("CustomerPolicyId");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.Customer", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.NationalIdType", "NationalIdType")
                        .WithMany()
                        .HasForeignKey("NationalIdTypeId");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerPolicy", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("WazenTransactions.Domain.Entities.PolicyType", "PolicyType")
                        .WithMany()
                        .HasForeignKey("PolicyTypeId");

                    b.HasOne("WazenTransactions.Domain.Entities.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.HasOne("WazenTransactions.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerPolicyAdditionalCoverage", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.CustomerPolicy", "CustomerPolicy")
                        .WithMany()
                        .HasForeignKey("CustomerPolicyId");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.CustomerVehicle", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("WazenTransactions.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("WazenTransactions.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
