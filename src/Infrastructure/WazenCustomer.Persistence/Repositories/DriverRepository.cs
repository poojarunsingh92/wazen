using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.TempDrivers.Queries.GetDriverVehicleViolationDetailsByVehicleId;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Persistence.Repositories
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        private readonly IMapper _mapper;
        ApplicationDbContext _db;
        public DriverRepository(ApplicationDbContext dbContext, IMapper mapper, ILogger<Driver> logger) : base(dbContext, logger)
        {
            _mapper = mapper;
            _db = dbContext;
        }

        public async Task<Driver> GetDriverByVehicleID(Guid VehicleID)
        {
            var tempDriver = _dbContext.Drivers.FirstOrDefault(x => x.CustomerVehicleId == VehicleID);
            return tempDriver;
        }

        public List<GetDriverVehicleViolationDetailsByVehicleIdVm> GetDriverListByVehicleId(Guid VehicleId)
        {
            var violationList = _dbContext.VehicleViolations.Where(x => x.VehicleID == VehicleId).ToList();
            var driverList = _db.Set<Driver>().Include(x => x.Vehicle).Where(x => x.CustomerVehicleId == VehicleId).Select(x => new GetDriverVehicleViolationDetailsByVehicleIdVm()
            {
                ID = VehicleId,
                VehiclePurposeId = x.Vehicle.VehiclePurposeId,
                AverageDailyMileage = x.Vehicle.AverageDailyMileage,
                ParkingGarage = x.Vehicle.ParkingGarage,
                EstimateValue = x.Vehicle.EstimateValue,
                IsSelected = x.Vehicle.IsSelected,
                DriverNationalId = x.DNID,
                DriverId = x.ID,
                DriverName = x.DriverName,
                DateOfBirth = x.DateOfBirth,
                EducationId = x.EducationId,
                MedicalIssueId = x.MedicalIssueId,
                IsMainDriver = x.IsMainDriver,
                VViolationData = _mapper.Map<List<VViolation>>(violationList)
            }).ToList();

            return driverList;
        }
    }
}
