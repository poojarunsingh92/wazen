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
namespace WazenCustomer.Application.Features.Account.Queries.CustomerExist
{
    public class CustomerExistQueryHandler : IRequestHandler<CustomerExistQuery, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerExistQueryHandler> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerExistQueryHandler(IMapper mapper, ILogger<CustomerExistQueryHandler> logger, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public async Task<Response<bool>> Handle(CustomerExistQuery request, CancellationToken cancellationToken)
        {
            Response<bool> response = new Response<bool>();
            var data=  _customerRepository.CheckCustomerExistWithMobileNumber(request.Mobile);
            response.Data = data;
            return response;
        }
    }
}