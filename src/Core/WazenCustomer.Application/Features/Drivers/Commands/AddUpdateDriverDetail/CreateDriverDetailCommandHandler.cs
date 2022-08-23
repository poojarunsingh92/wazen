using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Infrastructure;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Helper;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.Drivers.Commands.AddUpdateDriverDetail
{
    public class CreateDriverDetailCommandHandler : IRequestHandler<CreateDriverDetailCommand, Response<bool>>
    {
        private readonly IQueueService _queueService;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;


        public CreateDriverDetailCommandHandler(IMapper mapper, IDriverRepository driverRepository, IVehicleRepository vehicleRepository, ILogger<CreateDriverDetailCommandHandler> logger, IMediator mediator, IQueueService queueService)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRepository;
            _logger = logger;
            _mediator = mediator;
            _queueService = queueService;
        }

        public async Task<Response<bool>> Handle(CreateDriverDetailCommand request, CancellationToken cancellationToken)
        {
            var Response = new Response<bool>();

            if (request.isDetailPresent)
            {
                var vehicleDetails = new Vehicle()
                {
                    ID = request.VId,
                    VehiclePurposeId = request.VehiclePurposeId,
                    AverageDailyMileage = request.AverageDailyMileage,
                    ParkingGarage = request.ParkingGarage,
                    EstimateValue = request.EstimateValue,
                    IsSelected = request.IsSelected,
                    CustomerID = request.CustomerID,
                    SequenceNumber = request.SequenceNumber,
                };
                await _vehicleRepository.UpdateAsync(vehicleDetails);

                var driverDetails = new Driver()
                {
                    ID = request.DriverId,
                    CustomerVehicleId = request.VId,
                    DriverName = request.DriverName,
                    DateOfBirth = request.DateOfBirth,
                    Relation = request.Relation,
                    GenderId = request.GenderId,
                    EducationId = request.EducationId,
                    MedicalIssueId = request.MedicalIssueId,
                    IsMainDriver = request.IsMainDriver,
                    DNID = request.DriverNationalId

                };
                await _driverRepository.UpdateAsync(driverDetails);

                Response.Data = true;
                Response.Message = "Updated Successfully";
                Response.Succeeded = true;
            }
            else
            {
                var vehicleDetails = await _vehicleRepository.GetByIdAsync(request.ID);

                vehicleDetails.VehiclePurposeId = request.VehiclePurposeId;
                vehicleDetails.AverageDailyMileage = request.AverageDailyMileage;
                vehicleDetails.ParkingGarage = request.ParkingGarage;
                vehicleDetails.EstimateValue = request.EstimateValue;
                vehicleDetails.IsSelected = request.IsSelected;
               
                await _vehicleRepository.UpdateAsync(vehicleDetails);

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
                        MedicalIssueId = request.MedicalIssueId,
                        IsMainDriver = request.IsMainDriver,
                        DNID = request.DriverNationalId
                    };
                     
                    await _driverRepository.AddAsync(driverDetails);

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

                    await _driverRepository.UpdateAsync(driverCheck);

                    Response.Data = true;
                    Response.Message = "Updated  Successfully";
                    Response.Succeeded = true;
                }
            }
            return Response;
        }
    }
}
