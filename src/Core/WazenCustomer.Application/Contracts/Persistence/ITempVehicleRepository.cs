using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Contracts.Persistence
{
    public interface ITempVehicleRepository : IAsyncRepository<TempVehicle>
    {
        List<TempVehicleByCustomerIdVm> GetVehicleByCustomerId(Guid CustomerId);
        Task<TempVehicle> GetVehicleBySequenceNumberAndCustomerId(string SequenceNumber, Guid CustomerID);
        IEnumerable<GetAllListVM> GetTempVehicleDriverVehicleViolationListByCustomerId(Guid Customerid);
        Task<TempVehicle> FindVehicleBySequenceNumber(string SequenceNumber);
        Task<IEnumerable<TempVehicle>> GetVehicleListByCustomerId(Guid CustomerID);
        List<VehiclePolicyListByCustomerIDVm> GetTempVehiclePolicyCoverByCustomerID(Guid CustomerID);
        List<VehicleInformation> GetVehiclePolicyCoverByCustomerID(Guid CustomerID);
        //List<VehicleInformations> GetVehicleUpgradePolicyCoverByCustomerID(Guid CustomerID);
        Task<List<VehicleInformations>> GetVehicleUpgradePolicyCoverByCustomerID(Guid CustomerID);
        Task<List<VehicleInformationss>> GetVehicleRenewPolicyCoverByCustomerID(Guid CustomerID);

        Task<VehicleInfo> GetVehiclePolicy(Guid CustomerID, string SequenceNumber, string PolicyNumber, string InsuranceCompanyName);
    }
}