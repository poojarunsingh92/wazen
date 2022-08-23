using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetAllTempVehicles
{
    public class GetAllTempVehicleListQueryHandler : IRequestHandler<GetAllTempVehicleListQuery, Response<IEnumerable<TempVehicleListVm>>>
    {
        private readonly ITempVehicleRepository _tempVehicleRepository;
        private readonly IMapper _mapper;
        public GetAllTempVehicleListQueryHandler(IMapper mapper, ITempVehicleRepository tempVehicleRepository)
        {
            _mapper = mapper;
            _tempVehicleRepository = tempVehicleRepository;
        }

        public async Task<Response<IEnumerable<TempVehicleListVm>>> Handle(GetAllTempVehicleListQuery request, CancellationToken cancellationToken)
        {
            var allTempVehicles = await _tempVehicleRepository.ListAllAsync();
            var tempVehicleList = _mapper.Map<List<TempVehicleListVm>>(allTempVehicles);
            var response = new Response<IEnumerable<TempVehicleListVm>>(tempVehicleList);
            return response;
        }
    }
}