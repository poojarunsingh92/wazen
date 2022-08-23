using AutoMapper;
using WazenPolicy.Domain.Entities;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.CreateCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCancelCustomerPolicy;
using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateCustomerPolicy;
//using WazenPolicy.Application.Features.CustomerPolicy.Commands.UpdateExistingCustomerPolicyCommand;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyList;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetPolicyDetail;
using WazenPolicy.Application.Features.CancellationRequest.Commands.CreateCancellationRequest;
using WazenPolicy.Application.Features.CancellationRequest.Queries.GetCancellationRequestList;
using WazenPolicy.Application.Features.CancellationRequest.Queries.GetCancellationRequestDetail;
using WazenPolicy.Application.Features.CancellationRequest.Commands.UpdateCancellationRequest;
using WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerPolicyListByCustomerID;
using WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList;
using WazenPolicy.Application.Features.Vehicles.Queries.GetVehicleDetailByID;
using WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID;
using WazenPolicy.Application.Features.Drivers.Queries.GetDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Features.ViolationTypes;
using WazenPolicy.Application.Features.TempVehicles.Queries.GetTempVehicleDetailByID;
using WazenPolicy.Application.Features.TempCustomers.Queries.GetTempCustomerDetailByID;
using WazenPolicy.Application.Features.TempDrivers.Queries.GetTempDriverDetailByCustomerVehicleID;
using WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationDetailByVehicleID;
using WazenPolicy.Application.Features.TempVehicleViolations.Queries.GetTempVehicleViolationListByVehicleID;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID;
using WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationListByVehicleID;
using WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID;

namespace WazenPolicy.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CancellationRequest
            CreateMap<CancellationRequest, CreateCancellationRequestCommand>();
            CreateMap<CancellationRequest, CancellationRequestListVm>();
            CreateMap<CancellationRequest, CancellationRequestDto>();
            CreateMap<CancellationRequest, CancellationRequestDetailVm>();
            CreateMap<CancellationRequest, UpdateCancellationRequestCommand>().ReverseMap();

            //Customer
            CreateMap<Customer, CustomerDetailVm>().ReverseMap();

            //CustomerPolicy
            CreateMap<CustomerPolicy, CreateCustomerPolicyCommand>();
            CreateMap<CustomerPolicy, CustomerPolicyListVm>();
            CreateMap<CustomerPolicy, CustomerPolicyDto>();
            CreateMap<CustomerPolicy, CustomerPolicyDetailVm>();
            CreateMap<CustomerPolicy, UpdateCustomerPolicyCommand>().ReverseMap();
            CreateMap<CustomerPolicy, UpdateCancelCustomerPolicyCommand>().ReverseMap();
            //CreateMap<CustomerPolicy, UpdateExistingCustomerPolicyCommand>().ReverseMap();
            CreateMap<CustomerPolicy, GetCustomerPolicyListByCustomerIDVm>().ReverseMap();

            //Driver
            CreateMap<Driver, DriverDetailByCustomerVehicleIDVm>().ReverseMap();

            //InsuranceCompany
            CreateMap<InsuranceCompany, InsuranceCompanyListVm>().ReverseMap();

            //TempCustomer
            CreateMap<TempCustomer, TempCustomerDetailVm>().ReverseMap();
            CreateMap<TempCustomer, CustomerDetailVm>().ReverseMap();

            //TempDriver
            CreateMap<TempDriver, TempDriverDetailByCustomerVehicleIDVm>();
            CreateMap<TempDriver, DriverDetailByCustomerVehicleIDVm>();

            //TempVehicle
            CreateMap<TempVehicle, VehicleDetailVm>().ReverseMap();

            //TempVehicleViolation
            CreateMap<TempVehicleViolation, TempVehicleViolationDetailVm>().ReverseMap();
            CreateMap<TempVehicleViolation, TempVehicleViolationListVm>().ReverseMap();

            //Vehicle
            CreateMap<Vehicle, VehicleDetailVm>().ReverseMap();
            CreateMap<TempVehicle, TempVehicleDetailVm>();

            //ViolationType
            CreateMap<ViolationType, ViolationTypeDetailVm>().ReverseMap();
            CreateMap<ViolationTypeDetailVm, ViolationType>().ReverseMap();

            //VehicleViolation
            CreateMap<VehicleViolation, VehicleViolationDetailVm>().ReverseMap();
            CreateMap<VehicleViolation, VehicleViolationListVm>().ReverseMap();
        }
    }
}