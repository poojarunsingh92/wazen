using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Salutations.Queries.GetAllSalutations
{
    public class GetAllSalutationListQueryHandler : IRequestHandler<GetAllSalutationListQuery, Response<IEnumerable<SalutationListVm>>>
    {
        private readonly ISalutationRepository _salutationRepository;
        private readonly IMapper _mapper;
        public GetAllSalutationListQueryHandler(IMapper mapper, ISalutationRepository salutationRepository)
        {
            _mapper = mapper;
            _salutationRepository = salutationRepository;
        }
        public async Task<Response<IEnumerable<SalutationListVm>>> Handle(GetAllSalutationListQuery request, CancellationToken cancellationToken)
        {
            var allSalutation = await _salutationRepository.ListAllAsync();
            var SalutationList = _mapper.Map<List<SalutationListVm>>(allSalutation);
            var response = new Response<IEnumerable<SalutationListVm>>(SalutationList);
            return response;
        }
    }
}
