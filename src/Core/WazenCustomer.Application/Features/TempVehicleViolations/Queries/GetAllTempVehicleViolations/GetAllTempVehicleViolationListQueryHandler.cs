using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempVehicleViolations.Queries.GetAllTempVehicleViolations
{
    public class GetAllTempVehicleViolationListQueryHandler : IRequestHandler<GetAllTempVehicleViolationListQuery, Response<IEnumerable<TempVehicleViolationListVm>>>
    {
        private readonly ITempVehicleViolationRepository _tempVehicleViolationRepository;
        private readonly IMapper _mapper;
        public GetAllTempVehicleViolationListQueryHandler(IMapper mapper, ITempVehicleViolationRepository
            tempVehicleViolationRepository)
        {
            _mapper = mapper;
            _tempVehicleViolationRepository = tempVehicleViolationRepository;
        }
        public async Task<Response<IEnumerable<TempVehicleViolationListVm>>> Handle(GetAllTempVehicleViolationListQuery request, CancellationToken cancellationToken)
        {
            var allTempVehicleViolation = await _tempVehicleViolationRepository.ListAllAsync();
            var TempVehicleViolationList = _mapper.Map<List<TempVehicleViolationListVm>>(allTempVehicleViolation);
            var response = new Response<IEnumerable<TempVehicleViolationListVm>>(TempVehicleViolationList);
            return response;
        }
    }
}
