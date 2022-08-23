using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetVehiclePolicyListByCustomerID;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Persistence.Repositories
{
   public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly IMapper _mapper;
        ApplicationDbContext _db;
        public VehicleRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<Vehicle> logger) : base(dbContext, logger)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        /*public Task<IEnumerable<Vehicle>> GetRenewCustomerPolicyVehicleListByCustomerID(Guid CustomerID)
        {
            var vehicles = new Response<IEnumerable<Vehicle>>();
            return vehicles;
        }*/

        public async Task<IEnumerable<Vehicle>> GetVehicleListByCustomerID(Guid CustomerID)
        {
            var vehicles = await _dbContext.Vehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();
            return vehicles;
        }

        public List<VehicleInformations> GetVehiclePolicyCoverByCustomerID(Guid CustomerID)
        {
            var vehicles = _db.Set<Vehicle>().Where(x => x.CustomerID == CustomerID).Where(x => x.CustomerPolicies != null).Include(x => x.CustomerPolicies).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).ToList();
            var vehiclePolicyList = _mapper.Map<List<VehicleInformations>>(vehicles);
            return vehiclePolicyList;
        }
    }

   
}
