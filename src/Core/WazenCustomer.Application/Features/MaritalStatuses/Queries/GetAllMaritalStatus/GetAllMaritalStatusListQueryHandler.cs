using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.MaritalStatuses.Queries.GetAllMaritalStatus
{
    public class GetAllMaritalStatusListQueryHandler : IRequestHandler<GetAllMaritalStatusListQuery, Response<IEnumerable<MaritalStatusListVm>>>
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        private readonly IMapper _mapper;
        public GetAllMaritalStatusListQueryHandler(IMapper mapper, IMaritalStatusRepository maritalStatusRepository)
        {
            _mapper = mapper;
            _maritalStatusRepository = maritalStatusRepository;
        }
        public async Task<Response<IEnumerable<MaritalStatusListVm>>> Handle(GetAllMaritalStatusListQuery request, CancellationToken cancellationToken)
        {
            var allMaritalStatus = await _maritalStatusRepository.ListAllAsync();
            var MaritalStatusList = _mapper.Map<List<MaritalStatusListVm>>(allMaritalStatus);
            var response = new Response<IEnumerable<MaritalStatusListVm>>(MaritalStatusList);
            return response;
        }
    }
}
