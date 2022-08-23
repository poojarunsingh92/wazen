using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerById
{
  public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<GetCustomerListVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async System.Threading.Tasks.Task<Response<GetCustomerListVm>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                var resposeObject = new Response<GetCustomerListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var customerDto = _mapper.Map<GetCustomerListVm>(customer);
            var response = new Response<GetCustomerListVm>(customerDto, "success");
            return response;
        }
    }
}
