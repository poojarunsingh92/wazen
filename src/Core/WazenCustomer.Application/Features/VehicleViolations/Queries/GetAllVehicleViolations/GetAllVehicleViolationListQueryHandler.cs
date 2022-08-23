using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehicleViolations.Queries.GetAllVehicleViolations
{
    class GetAllVehicleViolationListQueryHandler : IRequestHandler<GetAllVehicleViolationListQuery, Response<IEnumerable<VehicleViolationListVm>>>
    {
        private readonly IVehicleViolationRepository _vehicleViolationRepository;
        private readonly IMapper _mapper;
        public GetAllVehicleViolationListQueryHandler(IMapper mapper, IVehicleViolationRepository 
            vehicleViolationRepository)
        {
            _mapper = mapper;
            _vehicleViolationRepository = vehicleViolationRepository;
        }
        public async Task<Response<IEnumerable<VehicleViolationListVm>>> Handle(GetAllVehicleViolationListQuery request, CancellationToken cancellationToken)
        {
            var allVehicleViolation = await _vehicleViolationRepository.ListAllAsync();
            var VehicleViolationList = _mapper.Map<List<VehicleViolationListVm>>(allVehicleViolation);
            var response = new Response<IEnumerable<VehicleViolationListVm>>(VehicleViolationList);
            return response;
        }
    }
}
