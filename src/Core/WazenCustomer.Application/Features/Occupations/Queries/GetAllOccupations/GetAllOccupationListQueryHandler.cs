using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Occupations.Queries.GetAllOccupations
{
    public class GetAllOccupationListQueryHandler : IRequestHandler<GetAllOccupationListQuery, Response<IEnumerable<OccupationListVm>>>
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IMapper _mapper;
        public GetAllOccupationListQueryHandler(IMapper mapper, IOccupationRepository occupationRepository)
        {
            _mapper = mapper;
            _occupationRepository = occupationRepository;
        }
        public async Task<Response<IEnumerable<OccupationListVm>>> Handle(GetAllOccupationListQuery request, CancellationToken cancellationToken)
        {
            var allOccupation = await _occupationRepository.ListAllAsync();
            var OccupationList = _mapper.Map<List<OccupationListVm>>(allOccupation);
            var response = new Response<IEnumerable<OccupationListVm>>(OccupationList);
            return response;
        }
    }
}
