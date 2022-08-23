using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempDrivers.Commands.AddAndUpdateDriverDetail
{
    public class CreateTempDriverDetailCommandHandler : IRequestHandler<CreateTempDriverDetailCommand, Response<bool>>
    {
        private readonly IQueueService _queueService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CreateTempDriverDetailCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, IDriverRepository driverRepository, ITempDriverRepository tempDriverRepository, IVehicleViolationRepository vehicleViolationRepository, ILogger<CreateTempDriverDetailCommandHandler> logger, IMediator mediator,  IQueueService queueService)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository = tempVehicleRepository;
            _driverRepository = driverRepository;
            _tempDriverRepository = tempDriverRepository;
            _vehicleViolationRepository = vehicleViolationRepository;
            _logger = logger;
            _mediator = mediator;
            _queueService = queueService;
        }

        public async Task<Response<bool>> Handle(CreateTempDriverDetailCommand request, CancellationToken cancellationToken)
        {
            var Response = new Response<bool>();

            if (request.isDetailPresent)
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(request.VId);
                if (vehicle != null)
                {
                    vehicle.VehiclePurposeId = request.VehiclePurposeId;
                    vehicle.AverageDailyMileage = request.AverageDailyMileage;
                    vehicle.ParkingGarage = request.ParkingGarage;
                    vehicle.EstimateValue = request.EstimateValue;
                    vehicle.IsSelected = request.IsSelected;
                    vehicle.CustomerID = request.CustomerID;
                    vehicle.SequenceNumber = request.SequenceNumber;

                    await _vehicleRepository.UpdateAsync(vehicle);
                   
                    await _queueService.SendMessageAsync<Vehicle>(vehicle, "Vehicle");

                    var driver = await _driverRepository.GetByIdAsync(request.DriverId);
                    if (driver == null)
                    {
                        Response.Data = false;
                        Response.Message = "No Record Found For Driver";
                        Response.Succeeded = true;
                        return Response;
                    }
                    driver.CustomerVehicleId = request.VId;
                    driver.DriverName = request.DriverName;
                    driver.DateOfBirth = request.DateOfBirth;
                    driver.Relation = request.Relation;
                    driver.GenderId = request.GenderId;
                    driver.EducationId = request.EducationId;
                    driver.OccupationId = request.OccupationId;
                    driver.MaritalStatusId = request.MaritalStatusId;
                    driver.MedicalIssueId = request.MedicalIssueId;
                    driver.IsMainDriver = request.IsMainDriver;
                    driver.DNID = request.DriverNationalId;
                    driver.ChildrenBelow16 = "0";

                    await _driverRepository.UpdateAsync(driver);
                    
                    await _queueService.SendMessageAsync<Driver>(driver, "Driver");
                    
                    Response.Data = true;
                    Response.Message = "Updated Successfully";
                    Response.Succeeded = true;
                }
                else
                {
                    var tempVehicle = await _tempVehicleRepository.GetByIdAsync(request.VId);
                    if (tempVehicle != null)
                    {
                        tempVehicle.VehiclePurposeId = request.VehiclePurposeId;
                        tempVehicle.AverageDailyMileage = request.AverageDailyMileage;
                        tempVehicle.ParkingGarage = request.ParkingGarage;
                        tempVehicle.EstimateValue = request.EstimateValue;
                        tempVehicle.IsSelected = request.IsSelected;
                        tempVehicle.CustomerID = request.CustomerID;
                        tempVehicle.SequenceNumber = request.SequenceNumber;

                        await _tempVehicleRepository.UpdateAsync(tempVehicle);
                        
                        await _queueService.SendMessageAsync<TempVehicle>(tempVehicle, "TempVehicle");

                        var tempDriver = await _tempDriverRepository.GetByIdAsync(request.DriverId);
                        if (tempDriver == null)
                        {
                            Response.Data = false;
                            Response.Message = "No Record Found For Driver";
                            Response.Succeeded = true;
                            return Response;
                        }
                        tempDriver.CustomerVehicleId = request.VId;
                        tempDriver.DriverName = request.DriverName;
                        tempDriver.DateOfBirth = request.DateOfBirth;
                        tempDriver.Relation = request.Relation;
                        tempDriver.GenderId = request.GenderId;
                        tempDriver.EducationId = request.EducationId;
                        tempDriver.OccupationId = request.OccupationId;
                        tempDriver.MaritalStatusId = request.MaritalStatusId;
                        tempDriver.MedicalIssueId = request.MedicalIssueId;
                        tempDriver.IsMainDriver = request.IsMainDriver;
                        tempDriver.DNID = request.DriverNationalId;
                        tempDriver.ChildrenBelow16 = "0";

                        await _tempDriverRepository.UpdateAsync(tempDriver);
                        
                        await _queueService.SendMessageAsync<TempDriver>(tempDriver, "TempDriver");
                        
                        Response.Data = true;
                        Response.Message = "Updated Successfully";
                        Response.Succeeded = true;
                    }
                }
            }
            else
            {
                var vehicleDetails = await _vehicleRepository.GetByIdAsync(request.ID);
                if (vehicleDetails != null)
                {
                    vehicleDetails.VehiclePurposeId = request.VehiclePurposeId;
                    vehicleDetails.AverageDailyMileage = request.AverageDailyMileage;
                    vehicleDetails.ParkingGarage = request.ParkingGarage;
                    vehicleDetails.EstimateValue = request.EstimateValue;
                    vehicleDetails.IsSelected = request.IsSelected;

                    await _vehicleRepository.UpdateAsync(vehicleDetails);
                   
                    await _queueService.SendMessageAsync<Vehicle>(vehicleDetails, "Vehicle");
                   
                    var driverCheck = await _driverRepository.GetDriverByVehicleID(request.ID);
                    if (driverCheck == null)
                    {
                        var driverDetails = new Driver()
                        {
                            ID = Guid.NewGuid(),
                            CustomerVehicleId = request.ID,
                            DriverName = request.DriverName,
                            DateOfBirth = request.DateOfBirth,
                            Relation = request.Relation,
                            GenderId = request.GenderId,
                            EducationId = request.EducationId,
                            OccupationId=request.OccupationId,
                            MaritalStatusId=request.MaritalStatusId,
                            MedicalIssueId = request.MedicalIssueId,
                            IsMainDriver = request.IsMainDriver,
                            DNID = request.DriverNationalId,
                            ChildrenBelow16="0"
                        };

                        var driverData = await _driverRepository.AddAsync(driverDetails);
                       
                        await _queueService.SendMessageAsync<Driver>(driverData, "Driver");
                        
                        Response.Data = true;
                        Response.Message = "Inserted Successfully";
                        Response.Succeeded = true;
                    }
                    else
                    {
                        driverCheck.DriverName = request.DriverName;
                        driverCheck.DateOfBirth = request.DateOfBirth;
                        driverCheck.Relation = request.Relation;
                        driverCheck.GenderId = request.GenderId;
                        driverCheck.EducationId = request.EducationId;
                        driverCheck.OccupationId = request.OccupationId;
                        driverCheck.MaritalStatusId = request.MaritalStatusId;
                        driverCheck.MedicalIssueId = request.MedicalIssueId;
                        driverCheck.IsMainDriver = request.IsMainDriver;
                        driverCheck.DNID = request.DriverNationalId;
                        driverCheck.ChildrenBelow16 = "0";

                        await _driverRepository.UpdateAsync(driverCheck);
                        
                        await _queueService.SendMessageAsync<Driver>(driverCheck, "Driver");
                        Response.Data = true;
                        Response.Message = "Updated Successfully";
                        Response.Succeeded = true;
                    }
                }
                else
                {
                    var tempVehicleDetails = await _tempVehicleRepository.GetByIdAsync(request.ID);

                    tempVehicleDetails.VehiclePurposeId = request.VehiclePurposeId;
                    tempVehicleDetails.AverageDailyMileage = request.AverageDailyMileage;
                    tempVehicleDetails.ParkingGarage = request.ParkingGarage;
                    tempVehicleDetails.EstimateValue = request.EstimateValue;
                    tempVehicleDetails.IsSelected = request.IsSelected;

                    await _tempVehicleRepository.UpdateAsync(tempVehicleDetails);
                    
                    await _queueService.SendMessageAsync<TempVehicle>(tempVehicleDetails, "TempVehicle");
                   

                    var driverCheck = await _tempDriverRepository.GetTempDriverByVehicleID(request.ID);
                    if (driverCheck == null)
                    {
                        var driverDetails = new TempDriver()
                        {
                            ID = Guid.NewGuid(),
                            CustomerVehicleId = request.ID,
                            DriverName = request.DriverName,
                            DateOfBirth = request.DateOfBirth,
                            Relation = request.Relation,
                            GenderId = request.GenderId,
                            EducationId = request.EducationId,
                            OccupationId=request.OccupationId,
                            MaritalStatusId=request.MaritalStatusId,
                            MedicalIssueId = request.MedicalIssueId,
                            IsMainDriver = request.IsMainDriver,
                            DNID = request.DriverNationalId,
                            ChildrenBelow16 = "0"
                        };

                        var driverData = await _tempDriverRepository.AddAsync(driverDetails);
                        
                        await _queueService.SendMessageAsync<TempDriver>(driverData, "TempDriver");
                       
                        Response.Data = true;
                        Response.Message = "Inserted Successfully";
                        Response.Succeeded = true;
                    }
                    else
                    {
                        driverCheck.DriverName = request.DriverName;
                        driverCheck.DateOfBirth = request.DateOfBirth;
                        driverCheck.Relation = request.Relation;
                        driverCheck.GenderId = request.GenderId;
                        driverCheck.EducationId = request.EducationId;
                        driverCheck.MedicalIssueId = request.MedicalIssueId;
                        driverCheck.IsMainDriver = request.IsMainDriver;
                        driverCheck.DNID = request.DriverNationalId;
                        driverCheck.ChildrenBelow16 = "0";

                        await _tempDriverRepository.UpdateAsync(driverCheck);
                      
                        await _queueService.SendMessageAsync<TempDriver>(driverCheck, "TempDriver");
                        Response.Data = true;
                        Response.Message = "Updated Successfully";
                        Response.Succeeded = true;
                    }
                }
            }
            return Response;
        }
    }
}