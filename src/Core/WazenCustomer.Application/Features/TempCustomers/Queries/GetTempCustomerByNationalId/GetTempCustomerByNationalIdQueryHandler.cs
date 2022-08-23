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

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetTempCustomerByNationalId
{
    public class GetTempCustomerByNationalIdQueryHandler : IRequestHandler<GetTempCustomerByNationalIdQuery, Response<TempCustomerByNationalIdVm>>
    {
        private readonly ITempCustomerRepository _tempCustomerRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempCustomerByNationalIdQueryHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository, ILogger<GetTempCustomerByNationalIdQueryHandler> logger)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
            _logger = logger;
        }
        public async Task<Response<TempCustomerByNationalIdVm>> Handle(GetTempCustomerByNationalIdQuery request, CancellationToken cancellationToken)
        {
            var tempCustomer = await _tempCustomerRepository.GetTempCustomerByNIN(request.NIN);
            if (tempCustomer == null)
            {
                var resposeObject = new Response<TempCustomerByNationalIdVm>(request.NIN + " is not available");
                return resposeObject;
            }

            var tempCustomerDetailDto = _mapper.Map<TempCustomerByNationalIdVm>(tempCustomer);
            var response = new Response<TempCustomerByNationalIdVm>(tempCustomerDetailDto, "success");
            return response;
        }
    }
}
