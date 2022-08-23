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

namespace WazenCustomer.Application.Features.Educations.Queries.GetEducationById
{
    public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, Response<GetEducationListVm>>
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetEducationByIdQueryHandler(IMapper mapper, IEducationRepository educationRepository, ILogger<GetEducationByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _logger = logger;
        }
        public async Task<Response<GetEducationListVm>> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
        {
            var education = await _educationRepository.GetByIdAsync(request.Id);
            if (education == null)
            {
                var resposeObject = new Response<GetEducationListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var educationDto = _mapper.Map<GetEducationListVm>(education);
            var response = new Response<GetEducationListVm>(educationDto, "success");
            return response;

        }
    }
}
