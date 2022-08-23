using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAllAdditionalCoverage
{
    public class GetAllAdditionalCoverageListQueryHandler : IRequestHandler<GetAllAdditionalCoverageListQuery, Response<IEnumerable<AdditionalCoverageListVm>>>
    {
        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;
        private readonly IMapper _mapper;
        public GetAllAdditionalCoverageListQueryHandler(IMapper mapper, IAdditionalCoverageRepository additionalCoverageRepository)
        {
            _mapper = mapper;
            _additionalCoverageRepository = additionalCoverageRepository;
        }
        public async Task<Response<IEnumerable<AdditionalCoverageListVm>>> Handle(GetAllAdditionalCoverageListQuery request, CancellationToken cancellationToken)
        {
            var allAdditionalCoverages = await _additionalCoverageRepository.ListAllAsync();
            var additionlCoverageList = _mapper.Map<List<AdditionalCoverageListVm>>(allAdditionalCoverages);
            var response = new Response<IEnumerable<AdditionalCoverageListVm>>(additionlCoverageList);
            return response;
        }
    }
}
