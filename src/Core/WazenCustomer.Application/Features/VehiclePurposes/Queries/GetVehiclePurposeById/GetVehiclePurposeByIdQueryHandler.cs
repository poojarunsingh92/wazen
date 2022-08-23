using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehiclePurposes.Queries.GetVehiclePurposeById
{
    public class GetVehiclePurposeByIdQueryHandler : IRequestHandler<GetVehiclePurposeByIdQuery, Response<GetVehiclePurposeListVm>>
    {
        private readonly IVehiclePurposeRepository _vehiclePurposeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVehiclePurposeByIdQueryHandler(IMapper mapper, IVehiclePurposeRepository vehiclePurposeRepository, ILogger<GetVehiclePurposeByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _vehiclePurposeRepository = vehiclePurposeRepository;
            _logger = logger;
        }
        public async Task<Response<GetVehiclePurposeListVm>> Handle(GetVehiclePurposeByIdQuery request, CancellationToken cancellationToken)
        {
            var vehiclePurpose = await _vehiclePurposeRepository.GetByIdAsync(request.Id);
            if (vehiclePurpose == null)
            {
                var resposeObject = new Response<GetVehiclePurposeListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var vehiclePurposeDto = _mapper.Map<GetVehiclePurposeListVm>(vehiclePurpose);
            var response = new Response<GetVehiclePurposeListVm>(vehiclePurposeDto, "success");
            return response;
        }
    }
}
