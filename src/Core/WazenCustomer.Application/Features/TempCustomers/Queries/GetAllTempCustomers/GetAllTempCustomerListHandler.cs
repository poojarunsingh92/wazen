using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetAllTempCustomers
{
    public class GetAllTempCustomerListHandler : IRequestHandler<GetAllTempCustomerListQuery, Response<IEnumerable<TempCustomerListVm>>>
    {
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        public GetAllTempCustomerListHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
        }

        public async Task<Response<IEnumerable<TempCustomerListVm>>> Handle(GetAllTempCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allTempCustomers = await _tempCustomerRepository.ListAllAsync();
            var tempCustomerList = _mapper.Map<List<TempCustomerListVm>>(allTempCustomers);
            var response = new Response<IEnumerable<TempCustomerListVm>>(tempCustomerList);
            return response;
        }
    }
}
