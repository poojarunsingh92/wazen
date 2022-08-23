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

namespace WazenCustomer.Application.Features.MaritalStatuses.Queries.GetMaritalStatusById
{
    public class GetMaritalStatusByIdQueryHandler : IRequestHandler<GetMaritalStatusByIdQuery, Response<GetMaritalStatusListVm>>
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetMaritalStatusByIdQueryHandler(IMapper mapper, IMaritalStatusRepository maritalStatusRepository, ILogger<GetMaritalStatusByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _maritalStatusRepository = maritalStatusRepository;
            _logger = logger;
        }
        public async Task<Response<GetMaritalStatusListVm>> Handle(GetMaritalStatusByIdQuery request, CancellationToken cancellationToken)
        {

            var maritalStatus = await _maritalStatusRepository.GetByIdAsync(request.Id);
            if (maritalStatus == null)
            {
                var resposeObject = new Response<GetMaritalStatusListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var maritalStatusDto = _mapper.Map<GetMaritalStatusListVm>(maritalStatus);
            var response = new Response<GetMaritalStatusListVm>(maritalStatusDto, "success");
            return response;
        }
    }
}
