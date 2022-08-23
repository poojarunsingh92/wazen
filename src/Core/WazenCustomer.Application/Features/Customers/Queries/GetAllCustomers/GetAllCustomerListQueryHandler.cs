using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomerListQueryHandler : IRequestHandler<GetAllCustomerListQuery, Response<IEnumerable<CustomerListVm>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomerListQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Response<IEnumerable<CustomerListVm>>> Handle(GetAllCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = await _customerRepository.ListAllAsync();
            var CustomerList = _mapper.Map<List<CustomerListVm>>(allCustomers);
            var response = new Response<IEnumerable<CustomerListVm>>(CustomerList);
            return response;
        }
    }
}
