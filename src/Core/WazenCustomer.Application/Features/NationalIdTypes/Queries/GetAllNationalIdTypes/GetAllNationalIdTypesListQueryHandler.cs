using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.NationalIdTypes.Queries.GetAllNationalIdTypes
{
    class GetAllNationalIdTypesListQueryHandler : IRequestHandler<GetAllNationalIdTypesListQuery, Response<IEnumerable<NationalIdTypesListVm>>>
    {
        private readonly INationalIdTypeRepository _nationalIdTypeRepository;
        private readonly IMapper _mapper;
        public GetAllNationalIdTypesListQueryHandler(IMapper mapper, INationalIdTypeRepository nationalIdTypeRepository)
        {
            _mapper = mapper;
            _nationalIdTypeRepository = nationalIdTypeRepository;
        }
        public async Task<Response<IEnumerable<NationalIdTypesListVm>>> Handle(GetAllNationalIdTypesListQuery request, CancellationToken cancellationToken)
        {
            var allNationalIdType = await _nationalIdTypeRepository.ListAllAsync();
            var NationalIdTypeList = _mapper.Map<List<NationalIdTypesListVm>>(allNationalIdType);
            var response = new Response<IEnumerable<NationalIdTypesListVm>>(NationalIdTypeList);
            return response;
        }
    }
}
