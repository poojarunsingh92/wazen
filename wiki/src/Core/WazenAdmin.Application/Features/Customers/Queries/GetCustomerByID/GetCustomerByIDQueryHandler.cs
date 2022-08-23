using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerByID
{
    public class GetCustomerByIDQueryHandler : IRequestHandler<GetCustomerByIDQuery, Response<CustomerByIDVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIDQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<Response<CustomerByIDVm>> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.ID);
            if (customer == null)
            {
                var resposeObject = new Response<CustomerByIDVm>(request.ID + " is not available");
                return resposeObject;
            }

            var customerDto = _mapper.Map<CustomerByIDVm>(customer);
            var response = new Response<CustomerByIDVm>(customerDto, "success");
            return response;
        }
    }
}
