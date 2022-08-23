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

namespace WazenAdmin.Application.Features.TempCustomers.Queries.GetTempCustomerList
{
    public class GetTempCustomerListQueryHandler : IRequestHandler<GetTempCustomerListQuery, Response<IEnumerable<TempCustomerListVm>>>
    {
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTempCustomerListQueryHandler(IMapper mapper, ITempCustomerRepository tempCustomerRepository, ILogger<GetTempCustomerListQueryHandler> logger)
        {
            _mapper = mapper;
            _tempCustomerRepository = tempCustomerRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<TempCustomerListVm>>> Handle(GetTempCustomerListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var tempCustomers = (await _tempCustomerRepository.ListAllAsync()).OrderBy(x => x.ID);

            var tempCustomerList = _mapper.Map<IEnumerable<TempCustomerListVm>>(tempCustomers);
            _logger.LogInformation("Hanlde Completed");
            if (tempCustomerList == null)
            {
                var resposeObject = new Response<IEnumerable<TempCustomerListVm>>(" Id is not found");
                return resposeObject;
            }
            return new Response<IEnumerable<TempCustomerListVm>>(tempCustomerList, "success");
        }
    }
}
