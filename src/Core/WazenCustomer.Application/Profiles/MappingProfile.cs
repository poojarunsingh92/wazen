using AutoMapper;
using System.Collections.Generic;
using WazenCustomer.Application.Features.Account.Commands.Register;
using WazenCustomer.Application.Features.AdditionalCoverage.Commands.CreateAdditionalCoverge;
using WazenCustomer.Application.Features.AdditionalCoverage.Commands.UpdateAdditionalCoverage;
using WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAllAdditionalCoverage;
using WazenCustomer.Application.Features.CancellationRequests.Commands.CreateCancellationRequest;
using WazenCustomer.Application.Features.CancellationRequests.Commands.DeleteCancellationRequest;
using WazenCustomer.Application.Features.CancellationRequests.Commands.UpdateCancellationRequest;
using WazenCustomer.Application.Features.CancellationRequests.Queries.GetCancellationRequestDetail;
using WazenCustomer.Application.Features.CancellationRequests.Queries.GetCancellationRequestList;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.CreateCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.DeleteCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Commands.UpdateCustomerPolicy;
using WazenCustomer.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID;
using WazenCustomer.Application.Features.Customers.Commands.CreateCustomer;
using WazenCustomer.Application.Features.Customers.Commands.DeleteCustomer;
using WazenCustomer.Application.Features.Customers.Commands.UpdateCustomer;
using WazenCustomer.Application.Features.Customers.Queries.GetAllCustomers;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerById;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerByNationalId;
using WazenCustomer.Application.Features.Customers.Queries.GetCustomerByUserId;
using WazenCustomer.Application.Features.CustomersOTP.Commands.CreateCustomersOTP;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.CreateCustomerVehicle;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.DeleteCustomerVehicle;
using WazenCustomer.Application.Features.CustomerVehicles.Commands.UpdateCustomerVehicle;
using WazenCustomer.Application.Features.Educations.Queries.GetAllEducations;
using WazenCustomer.Application.Features.Educations.Queries.GetEducationById;
using WazenCustomer.Application.Features.Genders.Queries.GetAllGenders;
using WazenCustomer.Application.Features.Genders.Queries.GetGenderById;
using WazenCustomer.Application.Features.MaritalStatuses.Queries.GetAllMaritalStatus;
using WazenCustomer.Application.Features.MaritalStatuses.Queries.GetMaritalStatusById;
using WazenCustomer.Application.Features.MedicalIssues.Queries.GetAllMedicalIssues;
using WazenCustomer.Application.Features.NationalIdTypes.Queries.GetAllNationalIdTypes;
using WazenCustomer.Application.Features.NationalIdTypes.Queries.GetNationalIdTypeById;
using WazenCustomer.Application.Features.Occupations.Queries.GetAllOccupations;
using WazenCustomer.Application.Features.Occupations.Queries.GetOccupationById;
using WazenCustomer.Application.Features.Salutations.Queries.GetAllSalutations;
using WazenCustomer.Application.Features.Salutations.Queries.GetSalutationById;
using WazenCustomer.Application.Features.SendMailToCustomer.Queries.SendMail;
using WazenCustomer.Application.Features.TempCustomers.Commands.CreateTempCustomer;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetAllTempCustomers;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteByNINAndDOB;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteVerifyOTP;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByCustomerId;
using WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByNationalId;
using WazenCustomer.Application.Features.TempCustomers.Queries.VerifyOTP;
using WazenCustomer.Application.Features.TempDrivers.Commands.AddAndUpdateDriverDetail;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetAllTempDrivers;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetTempDriverById;
using WazenCustomer.Application.Features.TempVehicles.Commands.CreateTempVehicle;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllTempVehicles;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleBySequenceNumberAndCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByVehicleId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.AddTempVehicleViolations;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.DeleteTempVehicleViolation;
using WazenCustomer.Application.Features.TempVehicleViolations.Commands.UpdateTempVehicleViolation;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetAllTempVehicleViolations;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationById;
using WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationsByVehicleId;
using WazenCustomer.Application.Features.VehicleImages.Commands.CreateVehicleImage;
using WazenCustomer.Application.Features.VehiclePurposes.Queries.GetAllVehiclePurposes;
using WazenCustomer.Application.Features.VehiclePurposes.Queries.GetVehiclePurposeById;
using WazenCustomer.Application.Features.Vehicles.Queries.GetAllVehicles;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleById;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleBySequenceNumberAndCustomerID;
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;
using WazenCustomer.Application.Features.VehicleViolations.Commands.AddVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.DeleteVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Commands.UpdateVehicleViolation;
using WazenCustomer.Application.Features.VehicleViolations.Queries.GetAllVehicleViolations;
using WazenCustomer.Application.Features.VehicleViolations.Queries.GetVehicleViolationById;
using WazenCustomer.Application.Features.ViolationTypes.Queries.GetAllViolationTypes;
using WazenCustomer.Application.Features.ViolationTypes.Queries.GetViolationTypeById;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CancellationPolicyAdditionalCoverage
            CreateMap<CustomerPolicyAdditionalCoverage, AdditionalCoverageListVm>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CreateAdditionalCoverageCommand>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CreateAdditionalCoverageDto>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverageVM>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverageVM>();
            CreateMap<CustomerPolicyAdditionalCoverage, UpdateAdditionalCoverageCommand>();
            CreateMap<UpdateAdditionalCoverageCommand, CustomerPolicyAdditionalCoverage>();

            CreateMap<AdditionalCoverageInformationss, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageInformationss, CustomerPolicyAdditionalCoverage>().ReverseMap();

            //CancellationRequest
            CreateMap<CancellationRequest, CreateCancellationRequestCommand>().ReverseMap();
            CreateMap<CancellationRequest, DeleteCancellationRequestCommand>().ReverseMap();
            CreateMap<CancellationRequest, UpdateCancellationRequestCommand>().ReverseMap();
            CreateMap<CancellationRequest, CancellationRequestDetailVm>().ReverseMap();
            CreateMap<CancellationRequest, CreateCancellationRequestDto>().ReverseMap();
            CreateMap<CancellationRequest, CancellationRequestListVm>().ReverseMap();

            //Customer
            CreateMap<Customer, RegistrationResponse>().ReverseMap();
            CreateMap<Customer, CreateRegistrationRequestCommand>().ReverseMap();
            CreateMap<Customer, GetQuoteByNINAndDOBVm>().ReverseMap();
            CreateMap<Customer, CustomerListVm>().ReverseMap();
            CreateMap<Customer, GetCustomerListVm>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerByNationalIdVm>().ReverseMap();
            CreateMap<Customer, GetCustomerByNationalIdQuery>().ReverseMap();
            CreateMap<Customer, GetCustomerByUserIdListVm>().ReverseMap();
            CreateMap<Customer, GetCustomerByUserIdQuery>().ReverseMap();
            CreateMap<Customer, GetQuoteVerifyOTPVm>().ReverseMap();
            CreateMap<Customer, VerifyOTPVm>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CustomerRequest>().ReverseMap();

            //CustomerOTP
            CreateMap<CustomerOTP, CustomersOTPDto>();


            //CustomerPolicy
            CreateMap<CustomerPolicy, IEnumerable<CustomerPolicy>>();
            CreateMap<CustomerPolicy, IEnumerable<CustomerPolicy>>().ReverseMap();
            CreateMap<CustomerPolicy, CreateCustomerPolicyCommand>().ReverseMap();
            CreateMap<CustomerPolicy, CustomerPolicyDto>().ReverseMap();
            CreateMap<CustomerPolicy, UpdateCustomerPolicyCommand>().ReverseMap();
            CreateMap<CustomerPolicy, DeleteCustomerPolicyCommand>().ReverseMap();
            CreateMap<CustomerPolicy, GetCustomerPolicyListByCustomerIDVm>().ReverseMap(); CreateMap<CustomerPolicy, GetCustomerPolicyListByCustomerIDVm>();
            CreateMap<PolicyData, CustomerPolicy>();
            CreateMap<PolicyData, CustomerPolicy>().ReverseMap();


            //CustomerVehicle
            CreateMap<CustomerVehicle, CreateCustomerVehicleCommand>().ReverseMap();
            CreateMap<CustomerVehicle, CustomerVehicleDto>().ReverseMap();
            CreateMap<CustomerVehicle, DeleteCustomerVehicleCommand>().ReverseMap();
            CreateMap<CustomerVehicle, UpdateCustomerVehicleCommand>().ReverseMap();

            //Driver
            CreateMap<Driver, GetDriverVehicleViolationDetailsByVehicleIdVm>();
            CreateMap<GetAllListVM, Driver>();

            //Education
            CreateMap<Education, EducationListVm>();
            CreateMap<Education, GenderListVm>();
            CreateMap<Education, GetEducationListVm>();

            //Gender
            CreateMap<Gender, GetGenderListVm>();
            CreateMap<Gender, GenderListVm>();

            //MaritalStatus
            CreateMap<MaritalStatus, MaritalStatusListVm>();
            CreateMap<MaritalStatus, GetMaritalStatusListVm>();

            //MedicalIssue
            CreateMap<MedicalIssue, MedicalIssuesListVm>();

            //NationalIdType
            CreateMap<NationalIdType, NationalIdTypesListVm>();
            CreateMap<NationalIdType, GetNationalIdListVm>();

            //Occupation
            CreateMap<Occupation, GetOccupationListVm>();
            CreateMap<Occupation, OccupationListVm>();

            //Salutation
            CreateMap<Salutation, SalutationListVm>();
            CreateMap<Salutation, GetSalutationListVm>();

            //TempCustomer
            CreateMap<TempCustomer, CreateTempCustomerCommand>();
            CreateMap<TempCustomer, CreateTempCustomerCommand>().ReverseMap();
            CreateMap<TempCustomer, TempCustomerDto>();
            CreateMap<TempCustomer, TempCustomerDto>().ReverseMap();
            CreateMap<TempCustomer, TempCustomerListVm>();
            CreateMap<TempCustomer, TempCustomerByCustomerIdVm>();
            CreateMap<TempCustomer, GetQuoteByNINAndDOBVm>();
            CreateMap<TempCustomer, GetQuoteVerifyOTPVm>();
            CreateMap<TempCustomer, GetCitizenByInfoVm>();
            CreateMap<TempCustomer, GetCitizenByInfoVm>().ReverseMap();
            CreateMap<TempCustomer, TempCustomerByNationalIdVm>().ReverseMap();
            CreateMap<TempCustomer, VerifyOTPVm>().ReverseMap();

            //TempDriver
            CreateMap<TempDriver, CreateTempDriverDetailCommand>();
            CreateMap<TempDriver, CreateTempDriverDetailDto>().ReverseMap();
            CreateMap<TempDriver, TempDriverDetailVm>();
            CreateMap<TempDriver, TempDriverListVm>();
            CreateMap<TempDriver, Driver>();
            CreateMap<TempDriver, GetDriverVehicleViolationDetailsByVehicleIdVm>();
            CreateMap<TempDriver, SendOTPToCustomerVm>();

            //TempVehicle
            CreateMap<TempVehicle, CreateTempVehicleCommand>().ReverseMap();
            CreateMap<TempVehicle, TempVehicleListVm>();
            CreateMap<TempVehicle, TempVehicleByVehicleIdVm>();
            CreateMap<TempVehicle, TempVehicleByCustomerIdVm>();
            CreateMap<TempVehicle, TempVehicleByCustomerIdVm>().ReverseMap();
            CreateMap<TempVehicle, getCarInfoBySequenceVm>();
            CreateMap<TempVehicle, CreateTempVehicleDto>();
            CreateMap<TempVehicle, TempVehicleBySeqNumAndCustomerIdVm>().ReverseMap();
            CreateMap<TempVehicle, Vehicle>();
            CreateMap<CreateTempVehicleDto, TempVehicle>().ReverseMap();
            CreateMap<Vehicle, VehiclePolicyListByCustomerIDVm>();
            CreateMap<CustomerPolicy, VehiclePolicyListByCustomerIDVm>();
            CreateMap<CustomerPolicyAdditionalCoverage, VehiclePolicyListByCustomerIDVm>();

            //TempVehicleImage
            CreateMap<TempVehicleImage, CreateVehicleImageCommand>().ReverseMap();
            CreateMap<TempVehicleImage, CreateVehicleImageDto>().ReverseMap();


            //TempVehicleViolation
            CreateMap<TempVehicleViolation, CreateTempVehicleViolationCommand>().ReverseMap();
            CreateMap<TempVehicleViolation, CreateTempVehicleViolationDto>().ReverseMap();
            CreateMap<TempVehicleViolation, DeleteTempVehicleViolationCommand>().ReverseMap();
            CreateMap<TempVehicleViolation, UpdateTempVehicleViolationCommand>().ReverseMap();
            CreateMap<TempVehicleViolation, GetAllTempVehicleViolationListQuery>().ReverseMap();
            CreateMap<TempVehicleViolation, TempVehicleViolationListVm>().ReverseMap();
            CreateMap<TempVehicleViolation, GetTempVehicleViolationListVm>().ReverseMap();
            CreateMap<TempVehicleViolation, GetTempVehicleViolationByIdQuery>().ReverseMap();
            CreateMap<TempVehicleViolation, GetTempVehicleViolationByVehicleIdListVm>().ReverseMap();
            CreateMap<TempVehicleViolation, GetTempVehicleViolationByVehicleIdQuery>().ReverseMap();
            CreateMap<TempVehicleViolation, VehicleViolation>().ReverseMap();
            CreateMap<TempVehicleViolation, UpdateTempVehicleViolationDto>();

            //Vehicle
            CreateMap<Vehicle, TempVehicleByCustomerIdVm>().ReverseMap();
            CreateMap<Vehicle, VehicleInformation>().ReverseMap();
            CreateMap<Vehicle, VehicleInformation>();
            CreateMap<Vehicle, VehicleByCustomerIdVm>();
            CreateMap<Vehicle, VehicleListVm>().ReverseMap();
            CreateMap<Vehicle, VehicleVm>().ReverseMap();
            CreateMap<Vehicle, VehicleListByCustomerIDVm>().ReverseMap();
            CreateMap<Vehicle, VehicleBySequenceNumberAndCustomerIDVm>().ReverseMap();
            CreateMap<Vehicle, TempVehicleBySeqNumAndCustomerIdVm>().ReverseMap();
            CreateMap<GetAllListVM, Vehicle>();
            CreateMap<Vehicle, VehicleInformations>();
            CreateMap<Vehicle, VehicleInformations>().ReverseMap();
            CreateMap<Vehicle, VehicleInformationss>();
            CreateMap<Vehicle, VehicleInformationss>().ReverseMap();
            CreateMap<Vehicle, VehicleInfo>();
            CreateMap<CustomerPolicy, CustomerPolicyInformation>();
            CreateMap<CustomerPolicyAdditionalCoverage, AdditionalCoverageInfo>();

            CreateMap<VehicleByCustomerIdVm, TempVehicleByCustomerIdVm>();

            //VehiclePurpose
            CreateMap<VehiclePurpose, VehiclePurposeListVm>();

            //VehicleViolation
            CreateMap<VehicleViolation, CreateVehicleViolationDto>();
            CreateMap<VehicleViolation, CreateVehicleViolationDto>().ReverseMap();
            CreateMap<VehicleViolation, CreateVehicleViolationCommand>();
            CreateMap<VehicleViolation, CreateVehicleViolationCommand>().ReverseMap();
            CreateMap<VehicleViolation, UpdateVehicleViolationCommand>();
            CreateMap<VehicleViolation, UpdateVehicleViolationCommand>().ReverseMap();
            CreateMap<VehicleViolation, DeleteVehicleViolationCommand>();
            CreateMap<VehicleViolation, VehicleViolationListVm>();
            CreateMap<VehicleViolation, GetVehicleViolationListVm>();
            CreateMap<VehicleViolation, CreateTempVehicleViolationDto>();
            CreateMap<CreateTempVehicleViolationCommand, VehicleViolation>();
            CreateMap<VehicleViolation, UpdateTempVehicleViolationDto>();
            //CreateMap<GetDriverVehicleViolationByVehicleIdVm, Violations>();
            CreateMap<TempVViolation, TempVehicleViolation>();
            CreateMap<TempVViolation, TempVehicleViolation>().ReverseMap();
            CreateMap<VViolation, VehicleViolation>();
            CreateMap<VViolation, VehicleViolation>().ReverseMap();
            CreateMap<TempVehicleViolation, TempVViolation>();
            CreateMap<TempVehicleViolation, TempVViolation>().ReverseMap();

            //ViolationType
            CreateMap<ViolationType, ViolationTypeListVm>();
            CreateMap<ViolationType, GetViolationTypeListVm>();

            //VehicleImage
            CreateMap<VehicleImage, CreateVehicleImageCommand>().ReverseMap();
            CreateMap<VehicleImage, CreateVehicleImageDto>().ReverseMap();

            //VehiclePurpose
            CreateMap<VehiclePurpose, GetVehiclePurposeListVm>();

            //
            CreateMap<CustomerPolicies1, CustomerPolicy>();
            CreateMap<CustomerPolicies1, CustomerPolicy>().ReverseMap();
            CreateMap<CustomerPolicy, CustomerPoliciess>();
            CreateMap<CustomerPolicy, CustomerPoliciess>().ReverseMap();
            CreateMap<CustomerPolicy, CustomerPoliciesss>();
            CreateMap<CustomerPolicy, CustomerPoliciesss>().ReverseMap();

            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverage>();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverage>().ReverseMap();


            CreateMap<VehicleInformations, Vehicle>();
            CreateMap<VehicleInformations, Vehicle>().ReverseMap();
            CreateMap<Vehicle, VehicleInformations>();
            CreateMap<Vehicle, VehicleInformations>().ReverseMap();


            CreateMap<CustomerPoliciess, CustomerPolicy>();
            CreateMap<CustomerPoliciess, CustomerPolicy>().ReverseMap();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverage>();
            CreateMap<CustomerPolicyAdditionalCoverage, CustomerPolicyAdditionalCoverage>().ReverseMap();

            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>().ReverseMap();

            CreateMap<AdditionalCoverageInformations, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageInformations, CustomerPolicyAdditionalCoverage>().ReverseMap();
        }
    }
}