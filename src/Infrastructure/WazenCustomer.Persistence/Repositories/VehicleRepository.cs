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
using WazenCustomer.Application.Features.Vehicles.Queries.GetVehicleListByCustomerID;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
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

        public List<VehicleByCustomerIdVm> GetVehiclesByCustomerID(Guid CustomerId)
        {
            var vehicles = _db.Set<Vehicle>().Include(x => x.Customer).Where(x => x.CustomerID == CustomerId).Select(x => new VehicleByCustomerIdVm
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

        public async Task<IEnumerable<Vehicle>> GetVehicleListByCustomerID(Guid CustomerID)
        {
            var vehicles = await _dbContext.Vehicles.Where(x => x.CustomerID == CustomerID).ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> GetVehicleBySequenceNumberAndCustomerID(string SequenceNumber, Guid CustomerID)
        {
            var vehicle = _dbContext.Vehicles.FirstOrDefault(x => x.SequenceNumber==SequenceNumber && x.CustomerID == CustomerID);
            return vehicle;
        }

        
        public IEnumerable<GetAllListVM> GetVehicleDriverVehicleViolationListByCustomerId(Guid Customerid)
        {
            var vehicles = _db.Set<Vehicle>().Where<Vehicle>(x => x.CustomerID == Customerid).Select(x => new GetAllListVM()
            {
                vehicleData = new WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList.GetAllvehicleList()
                {
                    customer = _db.Set<Customer>().Where<Customer>(a => x.CustomerID == a.ID).Select(p => new WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList.CustomerData() { nationalId = p.NationalIdTypeId }).FirstOrDefault(),
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
                    PolicyDetails = _db.Set<CustomerPolicy>().Where<CustomerPolicy>(z => z.VehicleId == x.ID).Select(b => new PolicyData()
                    {
                        PolicyTypeId = b.PolicyTypeId,
                        ExpiryDate = b.ExpiryDate
                    }).FirstOrDefault(),
                    driverDetails = _db.Set<Driver>().Where<Driver>(y => y.CustomerVehicleId == x.ID).Select(e => new WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList.DriverDetails()
                    {
                        driverId = e.ID,
                        dateOfBirth = e.DateOfBirth,
                        driverName = e.DriverName,
                        educationId = e.EducationId,
                        isMainDriver = e.IsMainDriver,
                        medicalIssueId = e.MedicalIssueId
                    }).FirstOrDefault(),
                    VehicleViolations = _db.Set<VehicleViolation>().Where<VehicleViolation>(j => j.VehicleID == x.ID).Select(m => new WazenCustomer.Application.Features.TempVehicles.Queries.GetAllList.VehicleViolationData()
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
    }

}
