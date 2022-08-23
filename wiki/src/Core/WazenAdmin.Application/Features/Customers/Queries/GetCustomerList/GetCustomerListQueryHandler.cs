using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, Response<IEnumerable<CustomerListVm>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCustomerListQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ILogger<GetCustomerListQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<CustomerListVm>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customers = (await _customerRepository.ListAllAsync()).OrderBy(x => x.ID);

            var customerList = _mapper.Map<IEnumerable<CustomerListVm>>(customers);
            _logger.LogInformation("Hanlde Completed");
            if (customerList == null)
            {
                var resposeObject = new Response<IEnumerable<CustomerListVm>>(" Id is not found");
                return resposeObject;
            }
            return new Response<IEnumerable<CustomerListVm>>(customerList, "success");
        }
    }
}
