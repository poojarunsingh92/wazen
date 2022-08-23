using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Infrastructure;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;
using WazenTransactions.Domain.Entities;

namespace WazenTransactions.Application.Features.AddtionalCoverages.Commands.AddAdditionalCoverage
{
    public class AddAdditionalCoverageCommandHandler : IRequestHandler<AddAdditionalCoverageCommand, Response<AdditionalCoverageDto>>
    {
        private readonly IQueueService _queueService;
        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddAdditionalCoverageCommandHandler> _logger;

        public AddAdditionalCoverageCommandHandler(IQueueService queueService, IMapper mapper, IAdditionalCoverageRepository additionalCoverageRepository, ILogger<AddAdditionalCoverageCommandHandler> logger)
        {
            _queueService = queueService;
            _mapper = mapper;
            _additionalCoverageRepository = additionalCoverageRepository;
            _logger = logger;
        }
        public async Task<Response<AdditionalCoverageDto>> Handle(AddAdditionalCoverageCommand request, CancellationToken cancellationToken)
        {

            var additionalCoverageResponse = new Response<AdditionalCoverageDto>();
            var validator = new AddAdditionalCoverageCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                additionalCoverageResponse.Succeeded = false;
                additionalCoverageResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    additionalCoverageResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var additionalCoverage = new CustomerPolicyAdditionalCoverage()
                {
                    CustomerPolicyId = request.CustomerPolicyId,
                    AdditionalCoverage = request.AdditionalCoverage
                };
                var additionalCover = await _additionalCoverageRepository.AddAsync(additionalCoverage);
                _queueService.SendMessageAsync<CustomerPolicyAdditionalCoverage>(additionalCover, "AdditionalCoverage");
                additionalCoverageResponse.Data = _mapper.Map<AdditionalCoverageDto>(additionalCover);
                additionalCoverageResponse.Succeeded = true;
                additionalCoverageResponse.Message = "success";
            }

            return additionalCoverageResponse;
        }
    }
}
