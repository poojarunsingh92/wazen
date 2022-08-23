using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.GetCustomerByNationalId
{
    public class GetCustomerByNationalIdQueryHandler : IRequestHandler<GetCustomerByNationalIdQuery, Response<CustomerByNationalIdVm>>
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCustomerByNationalIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<GetCustomerByNationalIdQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<Response<CustomerByNationalIdVm>> Handle(GetCustomerByNationalIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByNIN(request.NIN);
            if (customer == null)
            {
                var resposeObject = new Response<CustomerByNationalIdVm>(request.NIN + " is not available");
                return resposeObject;
            }

            var customerDetailDto = _mapper.Map<CustomerByNationalIdVm>(customer);
            var response = new Response<CustomerByNationalIdVm>(customerDetailDto, "success");
            return response;
        }
    }
}
