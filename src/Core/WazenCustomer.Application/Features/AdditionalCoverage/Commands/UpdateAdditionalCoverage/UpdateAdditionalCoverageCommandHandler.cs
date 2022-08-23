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

namespace WazenCustomer.Application.Features.AdditionalCoverage.Commands.UpdateAdditionalCoverage
{
    public class UpdateAdditionalCoverageCommandHandler : IRequestHandler<UpdateAdditionalCoverageCommand, Response<Guid>>
    {

        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAdditionalCoverageCommandHandler> _logger;

        public UpdateAdditionalCoverageCommandHandler(IMapper mapper, IAdditionalCoverageRepository additionalCoverageRepository, ILogger<UpdateAdditionalCoverageCommandHandler> logger)
        {
            _mapper = mapper;
            _additionalCoverageRepository = additionalCoverageRepository;
            _logger = logger;

        }
        public async Task<Response<Guid>> Handle(UpdateAdditionalCoverageCommand request, CancellationToken cancellationToken)
        {

            var additionalCoverageToUpdate = await _additionalCoverageRepository.GetByIdAsync(request.Id);


            if (additionalCoverageToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.Id + " is not available");
                return resposeObject;
            }

            _mapper.Map(request, additionalCoverageToUpdate, typeof(UpdateAdditionalCoverageCommand), typeof(CustomerPolicyAdditionalCoverage));
            await _additionalCoverageRepository.UpdateAsync(additionalCoverageToUpdate);

            return new Response<Guid>(request.Id, "Updated successfully ");
        }
    }
}
