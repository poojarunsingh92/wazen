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
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Commands.CreateAdditionalCoverge
{
    public class CreateAdditionalCoverageCommandHandler : IRequestHandler<CreateAdditionalCoverageCommand, Response<CreateAdditionalCoverageDto>>
    {

        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAdditionalCoverageCommandHandler> _logger;
    

        public CreateAdditionalCoverageCommandHandler(IMapper mapper, IAdditionalCoverageRepository additionalCoverageRepository, ILogger<CreateAdditionalCoverageCommandHandler> logger)
        {
            _mapper = mapper;
            _additionalCoverageRepository = additionalCoverageRepository;
            _logger = logger;
           
        }
        public async Task<Response<CreateAdditionalCoverageDto>> Handle(CreateAdditionalCoverageCommand request, CancellationToken cancellationToken)
        {
            
            var additionalCoverageResponse = new Response<CreateAdditionalCoverageDto>();
            var additionalCoverage = _mapper.Map<CustomerPolicyAdditionalCoverage>(request);
            additionalCoverage = await _additionalCoverageRepository.AddAsync(additionalCoverage);

            additionalCoverageResponse.Data = _mapper.Map<CreateAdditionalCoverageDto>(additionalCoverage);
            additionalCoverageResponse.Succeeded = true;
            additionalCoverageResponse.Message = "Success";
            return additionalCoverageResponse;
        }
    }
}