using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
    public class CustomerPolicyRepository : BaseRepository<CustomerPolicy>, ICustomerPolicyRepository
    {
        ApplicationDbContext _db;
        public CustomerPolicyRepository(ApplicationDbContext dbContext, ILogger<CustomerPolicy> logger) : base(dbContext, logger)
        {
            _db = dbContext;
        }

        
        public async Task<CustomerPolicy> GetCustomerPolicyByCustomerVehicleID(Guid CustomerVehicleID)
        {

            var customerVehicle = await _dbContext.CustomerPolicies.Include(x => x.CustomerPolicyAdditionalCoverage).FirstOrDefaultAsync(x => x.VehicleId == CustomerVehicleID);

            return customerVehicle;
        }

        public async Task<IEnumerable<CustomerPolicy>> GetCustomerPolicyListByCustomerIDPolicyType(Guid CustomerID, int PolicyType)
        {
            var customerPolicies = await _dbContext.CustomerPolicies.Where(x => x.CustomerId == CustomerID && x.PolicyTypeId == PolicyType).ToListAsync();
            return customerPolicies;
        }

        public async Task<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>> GetCustomerVehiclePolicyListByCustomerID(Guid CustomerID)
        {
            var vehicles = _db.Set<Vehicle>().Where<Vehicle>(x => x.CustomerID == CustomerID).Select(x => new RenewCustomerPolicyListByCustomerIDVm()
            {
                VehicleInformationData = new WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID.VehicleInformation()
                {
                    Id = x.ID,
                    VehicleRegistrationExpiryDate = x.VehicleRegistrationExpiryDate,
                    VehicleMake = x.VehicleMake,
                    VehicleModel = x.VehicleModel,
                    VehicleNumber = x.VehicleNumber,
                    PolicyInformationData = _db.Set<CustomerPolicy>().Where<CustomerPolicy>(y => y.VehicleId == x.ID).Select(e => new WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID.PolicyInformation()
                    {
                        PolicyId = e.Id,
                        PolicyRequestRefNo = e.PolicyRequestRefNo,
                        VehicleId = (Guid)e.VehicleId,
                        TransactionId = (Guid)e.TransactionId,
                        CustomerId = (Guid)e.CustomerId,
                        PolicyTypeId = (int)e.PolicyTypeId,
                        StartDate = e.StartDate,
                        ExpiryDate = e.ExpiryDate,
                        IssueDate = e.IssueDate,
                        PolicyNumber = e.PolicyNumber,
                        PolicyResponse = e.PolicyResponse,
                        ServiceChargeAmount = e.ServiceChargeAmount,
                        AdditionalCoverageAmount = e.AdditionalCoverageAmount,
                        VAT = e.VAT,
                        PremiumAmount = e.PremiumAmount,
                        GroundTotal = e.GroundTotal,
                        IsUpgraded = e.IsUpgraded,
                        IsCancelled = e.IsCancelled
                    }).FirstOrDefault()
                }
            }).ToList();

            return vehicles;
        }
    }
}
