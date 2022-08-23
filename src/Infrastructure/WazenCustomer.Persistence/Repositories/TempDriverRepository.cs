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
using WazenCustomer.Persistence.Repositories;

namespace WazenCustomer.Persistence.Repositories
{
    public class TempDriverRepository : BaseRepository<TempDriver>, ITempDriverRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        public TempDriverRepository(ApplicationDbContext dbContext, ILogger<TempDriver> logger, ITempVehicleViolationRepository tempVehicleViolationRepository, IMapper mapper) : base(dbContext, logger)
        {
            _db = dbContext;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
            _mapper = mapper;
        }

        public List<GetDriverVehicleViolationDetailsByVehicleIdVm> GetDriverListByVehicleId(Guid VehicleId)
        {
            var violationList = _dbContext.TempVehicleViolations.Where(x => x.VehicleID == VehicleId).ToList();
            var driverList = _db.Set<TempDriver>().Include(x => x.TempVehicle).Where(x => x.CustomerVehicleId == VehicleId).Select(x => new GetDriverVehicleViolationDetailsByVehicleIdVm()
            {
                ID = VehicleId,
                VehiclePurposeId = x.TempVehicle.VehiclePurposeId,
                AverageDailyMileage = x.TempVehicle.AverageDailyMileage,
                ParkingGarage = x.TempVehicle.ParkingGarage,
                EstimateValue = x.TempVehicle.EstimateValue,
                IsSelected = x.TempVehicle.IsSelected,
                DriverNationalId=x.DNID,
                DriverId = x.ID,
                DriverName = x.DriverName,
                DateOfBirth = x.DateOfBirth,
                EducationId = x.EducationId,
                MedicalIssueId = x.MedicalIssueId,
                IsMainDriver = x.IsMainDriver,
                TempVehicleViolation = _mapper.Map<List<TempVViolation>>(violationList)
            }).ToList();
           
            return driverList;
        }

        public async Task<TempDriver> GetTempDriverByVehicleID(Guid VehicleId)
        {
            var data = await _db.Set<TempDriver>().Include(x => x.TempVehicle).Where(x => x.CustomerVehicleId == VehicleId).FirstOrDefaultAsync(x => x.CustomerVehicleId == VehicleId);
            return data;
        }

        public async Task<TempDriver> GetTempDriverByVehicleId(Guid VehicleId)
        {
            var tempDriver = _dbContext.TempDrivers.FirstOrDefault(x => x.CustomerVehicleId == VehicleId);
            return tempDriver;
        }
    }
}