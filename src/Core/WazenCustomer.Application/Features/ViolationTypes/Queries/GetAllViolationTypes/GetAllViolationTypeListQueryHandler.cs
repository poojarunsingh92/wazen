using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.ViolationTypes.Queries.GetAllViolationTypes
{
    public class GetAllViolationTypeListQueryHandler : IRequestHandler<GetAllViolationTypeListQuery, Response<IEnumerable<ViolationTypeListVm>>>
    {
        private readonly IViolationTypeRepository _violationTypeRepository;
        private readonly IMapper _mapper;
        public GetAllViolationTypeListQueryHandler(IMapper mapper, IViolationTypeRepository violationTypeRepository)
        {
            _mapper = mapper;
            _violationTypeRepository = violationTypeRepository;
        }
        public async Task<Response<IEnumerable<ViolationTypeListVm>>> Handle(GetAllViolationTypeListQuery request, CancellationToken cancellationToken)
        {
            var allViolationTypes = await _violationTypeRepository.ListAllAsync();
            var ViolationTypeList = _mapper.Map<List<ViolationTypeListVm>>(allViolationTypes);
            var response = new Response<IEnumerable<ViolationTypeListVm>>(ViolationTypeList);
            return response;
        }
    }
}
