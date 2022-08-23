using AutoMapper;
using WazenTransactions.Application.Features.Transactions.Commands.CreateTransaction;
using WazenTransactions.Application.Features.Transactions.Commands.UpdateTransaction;
using WazenTransactions.Application.Features.Transactions.Queries.GetCustomerVehiclesTransactionList;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByCustomerId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionList;
using WazenTransactions.Domain.Entities;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionsListByUserId;
using WazenTransactions.Application.Features.Transactions.Queries.GetTransactionBetweenDates;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyDetailByID;
using WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID;
using WazenTransactions.Application.Features.CancellationRequests.Commands.CreateCancellationRequest;
using WazenTransactions.Application.Features.CustomerPolicies.Commands.CancelCustomerPolicy;
using WazenTransactions.Application.Features.CustomerPolicies.Commands.UpgradeCustomerPolicy;

namespace WazenTransactions.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CancellationRequest
            CreateMap<CancellationRequest, CreateCancellationRequestDto>();
            CreateMap<CancellationRequests, CancellationRequest>();

            //CancelPolicy
            CreateMap<CancelPolicy, CustomerPolicy>();
            
            //UPgradePolicy
            CreateMap<UpgradePolicy,  CustomerPolicy>();

            //CustomerPolicy
            CreateMap<CustomerPolicy, CustomerPolicyDetailVm>();

            //Transaction
            CreateMap<Transaction, CreateTransactionCommand>();
            CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionCommand>();
            CreateMap<Transaction, UpdateTransactionCommand>().ReverseMap();
            CreateMap<Transaction, TransactionListVm>();
            CreateMap<Transaction, GetTransactionListQuery>();
            CreateMap<Transaction, GetCustomerVehiclesTransactionListQuery>().ReverseMap();
            CreateMap<Transaction, GetCustomerVehiclesTransactionListQuery>();
            CreateMap<Transaction, GetTransactionDto>();
            CreateMap<Transaction, TransactionDetailVm>();
            CreateMap<Transaction, GetTransactionsListByCustomerIdQuery>().ReverseMap();
            CreateMap<Transaction, GetTransactionsListByCustomerIdQuery>();
            CreateMap<Transaction, GetTransactionsListByUserIdQuery>();
            CreateMap<Transaction, GetTransactionsDto>();
            CreateMap<Transaction, GetTransactionBetweenDatesVm>();
            CreateMap<AdditionalCoverageDto, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageDto, CustomerPolicyAdditionalCoverage>().ReverseMap();

            //
            CreateMap<Vehicle, VehiclePolicyListByCustomerIDVm>();
            CreateMap<CustomerPolicy, VehiclePolicyListByCustomerIDVm>();
            CreateMap<CustomerPolicyAdditionalCoverage, VehiclePolicyListByCustomerIDVm>();

            CreateMap<VehicleInformations, Vehicle>();
            CreateMap<VehicleInformations, Vehicle>().ReverseMap();
            CreateMap<Vehicle, VehicleInformations>();
            CreateMap<Vehicle, VehicleInformations>().ReverseMap();

            CreateMap<Vehicle, VehicleInformations>().ReverseMap();
            CreateMap<Vehicle, VehicleInformations>();

            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>();
            CreateMap<AdditionalCoverageInformation, CustomerPolicyAdditionalCoverage>().ReverseMap();
        }
    }
}
