using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.VehiclePurposes.Queries.GetAllVehiclePurposes
{
    public class GetAllVehiclePurposeListQueryHandler : IRequestHandler<GetAllVehiclePurposeListQuery, Response<IEnumerable<VehiclePurposeListVm>>>
    {
        private readonly IVehiclePurposeRepository _vehiclePurposeRepository;
        private readonly IMapper _mapper;
        public GetAllVehiclePurposeListQueryHandler(IMapper mapper, IVehiclePurposeRepository vehiclePurposeRepository)
        {
            _mapper = mapper;
            _vehiclePurposeRepository = vehiclePurposeRepository;
        }
        public async Task<Response<IEnumerable<VehiclePurposeListVm>>> Handle(GetAllVehiclePurposeListQuery request, CancellationToken cancellationToken)
        {
            var allVehiclePurposes = await _vehiclePurposeRepository.ListAllAsync();
            var VehiclePurposeList = _mapper.Map<List<VehiclePurposeListVm>>(allVehiclePurposes);
            var response = new Response<IEnumerable<VehiclePurposeListVm>>(VehiclePurposeList);
            return response;
        }
    }
}
