using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleByCustomerId;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleRenewPolicyListByCustomerID;
using WazenCustomer.Application.Features.TempVehicles.Queries.GetVehicleUpgradePolicyListByCustomerID;
using WazenCustomer.Domain.Entities;
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class TempVehicleRepository : BaseRepository<TempVehicle>, ITempVehicleRepository
    {
        ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public TempVehicleRepository(ApplicationDbContext dbContext, ILogger<TempVehicle> logger, IMapper mapper) : base(dbContext, logger)
        {
            _db = dbContext;
            _mapper = mapper;

        }

        public async Task<TempVehicle> FindVehicleBySequenceNumber(string SequenceNumber)
        {
            var data=await _db.Set<TempVehicle>().FirstOrDefaultAsync(x => x.SequenceNumber == SequenceNumber);
            return data;
        }

        public List<TempVehicleByCustomerIdVm> GetVehicleByCustomerId(Guid CustomerId)
        {
            var vehicles = _db.Set<TempVehicle>().Include(x => x.TempCustomer).Where(x => x.CustomerID == CustomerId).Select(x => new TempVehicleByCustomerIdVm
            {
                CustomerID = x.CustomerID,
                VehicleID = x.ID,
                VehicleMake = x.VehicleMake,
                VehicleModel = x.VehicleModel,
                VehicleNumber = x.VehicleNumber,
                SequenceNumber = x.SequenceNumber
            }).ToList();
            return vehicles;
        }

        public async Task<TempVehicle> GetVehicleBySequenceNumberAndCustomerId(string SequenceNumber, Guid CustomerID)
        {
            var vehicle = _dbContext.TempVehicles.FirstOrDefault(x => x.CustomerID == CustomerID && x.SequenceNumber == SequenceNumber);
            return vehicle;
        }

        public IEnumerable<GetAllListVM> GetTempVehicleDriverVehicleViolationListByCustomerId(Guid Customerid)
        {
            var vehicles = _db.Set<TempVehicle>().Where<TempVehicle>(x => x.CustomerID == Customerid).Select(x => new GetAllListVM()
            {
                vehicleData = new GetAllvehicleList()
                {
                    customer = _db.Set<TempCustomer>().Where<TempCustomer>(a => x.CustomerID == a.ID).Select(p => new CustomerData() { nationalId=p.NationalIdTypeId}).FirstOrDefault(),
                    vehicleMake = x.VehicleMake,
                    vehicleId = x.ID,
                    averageDailyMileage = x.AverageDailyMileage,
                    estimateValue = x.EstimateValue,
                    isSelected = x.IsSelected,
                    parkingGarage = x.ParkingGarage,
                    sequenceNumber = x.SequenceNumber,
                    vehicleModel = x.VehicleModel,
                    vehicleNumber = x.VehicleNumber,
                    vehiclePurposeId = x.VehiclePurposeId,
                    driverDetails = _db.Set<TempDriver>().Where<TempDriver>(y => y.CustomerVehicleId == x.ID).Select(e => new DriverDetails()
                    {
                        driverId=e.ID,
                        dateOfBirth = e.DateOfBirth,
                        driverName = e.DriverName,
                        educationId = e.EducationId,
                        isMainDriver = e.IsMainDriver,
                        medicalIssueId = e.MedicalIssueId
                    }).FirstOrDefault(),
                    VehicleViolations = _db.Set<TempVehicleViolation>().Where<TempVehicleViolation>(j => j.VehicleID == x.ID).Select(m => new VehicleViolationData()
                    {
                        vehicleId = m.VehicleID,
                        violationDate = m.ViolationDate,
                        id = m.ID,
                        violationTypeId = m.ViolationTypeId
                    }).ToList()
                }

            }).ToList();
            return vehicles;
        }

        public async Task<IEnumerable<TempVehicle>> GetVehicleListByCustomerId(Guid CustomerID)
        {
            var vehicle = await _dbContext.TempVehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();
            return vehicle;
        }

        public List<VehiclePolicyListByCustomerIDVm> GetTempVehiclePolicyCoverByCustomerID(Guid CustomerID)
        {
           
            throw new NotImplementedException();
        }

        public List<VehicleInformation> GetVehiclePolicyCoverByCustomerID(Guid CustomerID)
        {
            var vehicles = _db.Set<Vehicle>().Where(x => x.CustomerID == CustomerID).Where(x => x.CustomerPolicies != null).Include(x => x.CustomerPolicies).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).ToList();
            var vehiclePolicyList = _mapper.Map<List<VehicleInformation>>(vehicles);
            return vehiclePolicyList;
        }

        /*public List<VehicleInformations> GetVehicleUpgradePolicyCoverByCustomerID(Guid CustomerID)
        {
            var vehicles = _db.Set<Vehicle>().Where(x => x.CustomerID == CustomerID).Include(x => x.CustomerPolicies).Where(x =>x.CustomerPolicies.PolicyType.Id==1).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).ToList();
            var vehiclePolicyList = _mapper.Map<List<VehicleInformations>>(vehicles);
            return vehiclePolicyList;
        }*/

        public async Task<List<VehicleInformations>> GetVehicleUpgradePolicyCoverByCustomerID(Guid CustomerID)
        {
            var vehicles = await _db.Set<Vehicle>().Where(x => x.CustomerID == CustomerID).Include(x => x.CustomerPolicies).Where(x => x.CustomerPolicies.PolicyTypeId == 1).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).ToListAsync();
            var vehiclePolicyList = _mapper.Map<List<VehicleInformations>>(vehicles);
            return vehiclePolicyList;
        }

        /*public async Task<List<VehicleInformationss>> GetVehicleRenewPolicyCoverByCustomerID(Guid CustomerID)
        {
            var Date1 = DateTime.UtcNow;
            var Date2 = DateTime.UtcNow.AddDays(30);
            var vehicles = await _db.Set<Vehicle>().Include(x => x.CustomerPolicies).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).Where(x => x.CustomerID == CustomerID).Where(x => (x.CustomerPolicies.ExpiryDate >= Date1 && x.CustomerPolicies.ExpiryDate <= Date2) || x.CustomerPolicies.ExpiryDate < Date1).ToListAsync();

            var vehiclePolicyList = _mapper.Map<List<VehicleInformationss>>(vehicles);
            return vehiclePolicyList;
        }*/

        public async Task<List<VehicleInformationss>> GetVehicleRenewPolicyCoverByCustomerID(Guid CustomerID)
        {
            var Date1 = DateTime.UtcNow;
            var Date2 = DateTime.UtcNow.AddDays(30);
            var vehicles = await _db.Set<Vehicle>().Include(x => x.CustomerPolicies).Include(x => x.CustomerPolicies.CustomerPolicyAdditionalCoverage).Where(x => x.CustomerID == CustomerID && x.CustomerPolicies.ExpiryDate >= Date1 && x.CustomerPolicies.ExpiryDate <= Date2).ToListAsync();

            var vehiclePolicyList = _mapper.Map<List<VehicleInformationss>>(vehicles);
            return vehiclePolicyList;
        }

        public async Task<VehicleInfo> GetVehiclePolicy(Guid CustomerID, string SequenceNumber, string PolicyNumber, string InsuranceCompanyName)
        {
            var vehicle = await _db.Set<Vehicle>().Include(x => x.CustomerPolicies).Where(p=>p.CustomerPolicies.PolicyNumber==PolicyNumber).Include(x => x.Customer).Where(y => y.CustomerID == CustomerID && y.SequenceNumber == SequenceNumber).FirstOrDefaultAsync();
            var vehicleResponse = _mapper.Map<VehicleInfo>(vehicle);
            return vehicleResponse;
        }
    }
}