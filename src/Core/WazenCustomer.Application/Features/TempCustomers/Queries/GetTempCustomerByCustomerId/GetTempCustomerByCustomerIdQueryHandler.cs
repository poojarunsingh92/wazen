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

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByCustomerId
{
    public class GetTempCustomerByCustomerIdQueryHandler : IRequestHandler<GetTempCustomerByCustomerIdQuery, Response<TempCustomerByCustomerIdVm>>
    {

        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempCustomerByCustomerIdQueryHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository, ILogger<GetTempCustomerByCustomerIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
            _logger = logger;
        }

        public async Task<Response<TempCustomerByCustomerIdVm>> Handle(GetTempCustomerByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var tempCustomer = await _tempCustomerRepository.GetByIdAsync(request.Id);
            if (tempCustomer == null)
            {
                var resposeObject = new Response<TempCustomerByCustomerIdVm>(request.Id + " is not available");
                return resposeObject;
            }

            var tempCustomerDetailDto = _mapper.Map<TempCustomerByCustomerIdVm>(tempCustomer);
            var response = new Response<TempCustomerByCustomerIdVm>(tempCustomerDetailDto, "success");
            return response;
        }
    }
}
