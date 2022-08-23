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

namespace WazenPolicy.Application.Features.ViolationTypes.Queries.GetViolationTypeDetailByID
{
    public class GetViolationTypeDetailByIDQueryHandler : IRequestHandler<GetViolationTypeDetailByIDQuery, Response<ViolationTypeDetailVm>>
    {
        private readonly IViolationTypeRepository _violationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetViolationTypeDetailByIDQueryHandler(IMapper mapper, IViolationTypeRepository violationTypeRepository, ILogger<GetViolationTypeDetailByIDQueryHandler> logger)
        {
            _mapper = mapper;
            _violationTypeRepository = violationTypeRepository;
            _logger = logger;
        }
        public async Task<Response<ViolationTypeDetailVm>> Handle(GetViolationTypeDetailByIDQuery request, CancellationToken cancellationToken)
        {
            var violationType = await _violationTypeRepository.GetByIdAsync(request.ID);
            if (violationType == null)
            {
                var resposeObject = new Response<ViolationTypeDetailVm>(request.ID + " is not available");
                return resposeObject;
            }

            var vehicleDto = _mapper.Map<ViolationTypeDetailVm>(violationType);
            var response = new Response<ViolationTypeDetailVm>(vehicleDto, "success");
            return response;

        }
    }
}
