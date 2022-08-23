using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Genders.Queries.GetAllGenders
{
    public class GetAllGenderLishQueryHandler : IRequestHandler<GetAllGenderListQuery, Response<IEnumerable<GenderListVm>>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        public GetAllGenderLishQueryHandler(IMapper mapper, IGenderRepository genderRepository)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
        }
        public async Task<Response<IEnumerable<GenderListVm>>> Handle(GetAllGenderListQuery request, CancellationToken cancellationToken)
        {
            var allGenders = await _genderRepository.ListAllAsync();
            var GenderList = _mapper.Map<List<GenderListVm>>(allGenders);
            var response = new Response<IEnumerable<GenderListVm>>(GenderList);
            return response;
        }
    }
}
