using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Features.VehicleViolations.Commands.UpdateVehicleViolation;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Commands.UpdateTempVehicleViolation
{
    public class UpdateTempVehicleViolationCommandHandler : IRequestHandler<UpdateTempVehicleViolationCommand, Response<UpdateTempVehicleViolationDto>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;

        public UpdateTempVehicleViolationCommandHandler(IMapper mapper, IVehicleViolationRepository vehicleViolationRepository, ITempVehicleViolationRepository tempVehicleViolationRepository)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
        }

        public async Task<Response<UpdateTempVehicleViolationDto>> Handle(UpdateTempVehicleViolationCommand request, CancellationToken cancellationToken)
        {
            var vehicleViolationToUpdate = await _vehicleViolationRepository.GetByIdAsync(request.ID);
            if (vehicleViolationToUpdate == null)
            {
                var tempVehicleViolationToUpdate = await _tempVehicleViolationRepository.GetByIdAsync(request.ID);

                if (tempVehicleViolationToUpdate == null)
                {
                    var resposeObject = new Response<UpdateTempVehicleViolationDto>(request.ID + " is not available");
                    return resposeObject;
                }
                _mapper.Map(request, tempVehicleViolationToUpdate, typeof(UpdateTempVehicleViolationCommand), typeof(TempVehicleViolation));
                await _tempVehicleViolationRepository.UpdateAsync(tempVehicleViolationToUpdate);
                var tempVehicleViolation = await _tempVehicleViolationRepository.GetByIdAsync(request.ID);
                var tempVehicleViolationDto = _mapper.Map<UpdateTempVehicleViolationDto>(tempVehicleViolation);
                return new Response<UpdateTempVehicleViolationDto>(tempVehicleViolationDto, "Updated successfully ");
            }
            UpdateVehicleViolationCommand requestMain = new UpdateVehicleViolationCommand()
            {
                ID = request.ID,
                VehicleID = request.VehicleID,
                ViolationDate = request.ViolationDate,
                ViolationTypeId = request.ViolationTypeId
            };
            _mapper.Map(requestMain, vehicleViolationToUpdate, typeof(UpdateVehicleViolationCommand), typeof(VehicleViolation));
            await _vehicleViolationRepository.UpdateAsync(vehicleViolationToUpdate);
            var vehicleViolation = await _vehicleViolationRepository.GetByIdAsync(request.ID);
            var vehicleViolationDto = _mapper.Map<UpdateTempVehicleViolationDto>(vehicleViolation);
            return new Response<UpdateTempVehicleViolationDto>(vehicleViolationDto, "Updated successfully ");            
        }
    }
}