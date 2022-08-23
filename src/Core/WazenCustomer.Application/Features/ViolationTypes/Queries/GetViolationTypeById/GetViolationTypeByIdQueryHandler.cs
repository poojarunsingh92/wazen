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

namespace WazenCustomer.Application.Features.ViolationTypes.Queries.GetViolationTypeById
{
    public class GetViolationTypeByIdQueryHandler : IRequestHandler<GetViolationTypeByIdQuery, Response<GetViolationTypeListVm>>
    {
        private readonly IViolationTypeRepository _violationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetViolationTypeByIdQueryHandler(IMapper mapper, IViolationTypeRepository violationTypeRepository, ILogger<GetViolationTypeByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _violationTypeRepository = violationTypeRepository;
            _logger = logger;
        }

        public async Task<Response<GetViolationTypeListVm>> Handle(GetViolationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var violationType = await _violationTypeRepository.GetByIdAsync(request.Id);
            if (violationType == null)
            {
                var resposeObject = new Response<GetViolationTypeListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var violationTypeDto = _mapper.Map<GetViolationTypeListVm>(violationType);
            var response = new Response<GetViolationTypeListVm>(violationTypeDto, "success");
            return response;
        }
    }
}
