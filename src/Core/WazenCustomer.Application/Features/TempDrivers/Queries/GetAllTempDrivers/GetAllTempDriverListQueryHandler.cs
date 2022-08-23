using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempDrivers.Queries.GetAllTempDrivers
{
    public class GetAllTempDriverListQueryHandler : IRequestHandler<GetAllTempDriverListQuery, Response<IEnumerable<TempDriverListVm>>>
    {
        private readonly ITempDriverRepository _tempDriverRepository;
        private readonly IMapper _mapper;
        public GetAllTempDriverListQueryHandler(IMapper mapper, ITempDriverRepository tempDriverRepository)
        {
            _mapper = mapper;
            _tempDriverRepository = tempDriverRepository;
        }

        public async Task<Response<IEnumerable<TempDriverListVm>>> Handle(GetAllTempDriverListQuery request, CancellationToken cancellationToken)
        {
            var allTempDrivers = await _tempDriverRepository.ListAllAsync();
            var tempDriverList = _mapper.Map<List<TempDriverListVm>>(allTempDrivers);
            var response = new Response<IEnumerable<TempDriverListVm>>(tempDriverList);
            return response;
        }
    }
}