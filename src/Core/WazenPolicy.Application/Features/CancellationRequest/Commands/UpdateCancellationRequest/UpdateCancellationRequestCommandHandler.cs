using AutoMapper;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Exceptions;
using WazenPolicy.Application.Responses;
using WazenPolicy.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WazenPolicy.Application.Features.CancellationRequest.Commands.UpdateCancellationRequest
{
    public class UpdateCancellationRequestCommandHandler : IRequestHandler<UpdateCancellationRequestCommand, Response<Guid>>
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateCancellationRequestCommandHandler(IMapper mapper, ICancellationRequestRepository cancellationRequestRepository, ILogger<UpdateCancellationRequestCommandHandler> logger)
        {
            _mapper = mapper;
            _cancellationRequestRepository = cancellationRequestRepository;
        }

        public async Task<Response<Guid>> Handle(UpdateCancellationRequestCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var cancellationRequestToUpdate = await _cancellationRequestRepository.GetByIdAsync(request.ID);

            if (cancellationRequestToUpdate == null)
            {
                var resposeObject = new Response<Guid>(request.ID + " is not available");
                return resposeObject;
            }

            var validator = new UpdateCancellationRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, cancellationRequestToUpdate, typeof(UpdateCancellationRequestCommand), typeof(Domain.Entities.CancellationRequest));

            await _cancellationRequestRepository.UpdateAsync(cancellationRequestToUpdate);
            _logger.LogInformation("Handle Completed");
            return new Response<Guid>(request.ID, "Updated successfully ");
        }
    }
}
