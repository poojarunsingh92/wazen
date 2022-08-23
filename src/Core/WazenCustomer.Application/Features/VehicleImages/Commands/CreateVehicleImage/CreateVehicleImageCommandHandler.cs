using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.VehicleImages.Commands.CreateVehicleImage
{
   public class CreateVehicleImageCommandHandler : IRequestHandler<CreateVehicleImageCommand, Response<CreateVehicleImageDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IVehicleImageRepository _vehicleImageRepository;
        private readonly ITempVehicleImageRepository _tempVehicleImageRepository;
        private readonly IMapper _mapper;

        public CreateVehicleImageCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository, ITempVehicleRepository tempVehicleRepository, IVehicleImageRepository vehicleImageRepository, ITempVehicleImageRepository tempVehicleImageRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _tempVehicleRepository= tempVehicleRepository;
            _vehicleImageRepository = vehicleImageRepository;
            _tempVehicleImageRepository= tempVehicleImageRepository;
        }

        public async Task<Response<CreateVehicleImageDto>> Handle(CreateVehicleImageCommand request, CancellationToken cancellationToken)
        {
            var createVehicleimageCommandResponse = new Response<CreateVehicleImageDto>();

            var validator = new CreateVehicleImageCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createVehicleimageCommandResponse.Succeeded = false;
                createVehicleimageCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVehicleimageCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleID);
                if(vehicle==null)
                {
                    var tempVehicle = await _tempVehicleRepository.GetByIdAsync(request.VehicleID);
                    if (tempVehicle == null)
                    {
                        var resposeObject = new Response<CreateVehicleImageDto>(request.VehicleID + " is not available");
                        return resposeObject;
                    }
                    var tempVehicleImage = new TempVehicleImage() { VehicleID = request.VehicleID, VehicleImages = request.VehicleImages };
                    tempVehicleImage = await _tempVehicleImageRepository.AddAsync(tempVehicleImage);
                    createVehicleimageCommandResponse.Data = _mapper.Map<CreateVehicleImageDto>(tempVehicleImage);
                    createVehicleimageCommandResponse.Succeeded = true;
                    createVehicleimageCommandResponse.Message = "success";
                    return createVehicleimageCommandResponse;
                }
                var vehicleimage = new VehicleImage() { VehicleID = request.VehicleID, VehicleImages = request.VehicleImages };
                vehicleimage = await _vehicleImageRepository.AddAsync(vehicleimage);
                createVehicleimageCommandResponse.Data = _mapper.Map<CreateVehicleImageDto>(vehicleimage);
                createVehicleimageCommandResponse.Succeeded = true;
                createVehicleimageCommandResponse.Message = "success";
            }
            return createVehicleimageCommandResponse;
        }
    }
}