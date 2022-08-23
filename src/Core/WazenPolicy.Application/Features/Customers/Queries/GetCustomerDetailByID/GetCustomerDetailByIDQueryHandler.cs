using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID
{
    public class GetCustomerDetailByIDQueryHandler : IRequestHandler<GetCustomerDetailByIDQuery, Response<CustomerDetailVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCustomerDetailByIDQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<GetCustomerDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<Response<CustomerDetailVm>> Handle(GetCustomerDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.ID);
            if (customer == null)
            {
                var resposeObject = new Response<CustomerDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var customerDto = _mapper.Map<CustomerDetailVm>(customer);
            var response = new Response<CustomerDetailVm>(customerDto, "success");
            return response;

        }
    }
}
