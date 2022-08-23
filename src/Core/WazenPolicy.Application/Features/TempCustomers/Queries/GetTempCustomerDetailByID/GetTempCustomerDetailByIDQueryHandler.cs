using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Features.Customers.Queries.GetCustomerDetailByID;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.TempCustomers.Queries.GetTempCustomerDetailByID
{
    public class GetTempCustomerDetailByIDQueryHandler : IRequestHandler<GetTempCustomerDetailByIDQuery, Response<CustomerDetailVm>>
    {
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempCustomerDetailByIDQueryHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository, ILogger<GetTempCustomerDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
            _logger = logger;
        }
        public async Task<Response<CustomerDetailVm>> Handle(GetTempCustomerDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var customer = await _tempCustomerRepository.GetByIdAsync(request.ID);
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
