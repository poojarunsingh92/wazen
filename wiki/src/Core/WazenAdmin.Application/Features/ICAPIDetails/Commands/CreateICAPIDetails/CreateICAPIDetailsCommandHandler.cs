using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Domain.Entities;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.CreateICAPIDetails
{
    public class CreateICAPIDetailsCommandHandler : IRequestHandler<CreateICAPIDetailsCommand, Response<CreateICAPIDetailsDto>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateICAPIDetailsCommandHandler> _logger;
        public CreateICAPIDetailsCommandHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository, ILogger<CreateICAPIDetailsCommandHandler> logger)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _logger = logger;
        }

        public async Task<Response<CreateICAPIDetailsDto>> Handle(CreateICAPIDetailsCommand request, CancellationToken cancellationToken)
        {
            var createICAPIDetailsCommandResponse = new Response<CreateICAPIDetailsDto>();

            var validator = new CreateICAPIDetailsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createICAPIDetailsCommandResponse.Succeeded = false;
                createICAPIDetailsCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createICAPIDetailsCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var iCAPIDetails = new ICAPIDetail()
                {
                    ICID = request.ICID,
                    EndPointURL = request.EndPointURL,
                    RequestType = request.RequestType,
                    Header = request.Header,
                    Body = request.Body,
                    APIType = request.APIType 
                };
                iCAPIDetails = await _iCAPIDetailsRepository.AddAsync(iCAPIDetails);
                createICAPIDetailsCommandResponse.Data = _mapper.Map<CreateICAPIDetailsDto>(iCAPIDetails);
                createICAPIDetailsCommandResponse.Succeeded = true;
                createICAPIDetailsCommandResponse.Message = "success";
            }

            return createICAPIDetailsCommandResponse;
        }
    }
}
