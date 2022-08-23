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

namespace WazenCustomer.Application.Features.Salutations.Queries.GetSalutationById
{
    public class GetSalutationByIdQueryHandler : IRequestHandler<GetSalutationByIdQuery, Response<GetSalutationListVm>>
    {
        private readonly ISalutationRepository _salutationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetSalutationByIdQueryHandler(IMapper mapper, ISalutationRepository saluationRepository, ILogger<GetSalutationByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _salutationRepository = saluationRepository;
            _logger = logger;
        }

        public async Task<Response<GetSalutationListVm>> Handle(GetSalutationByIdQuery request, CancellationToken cancellationToken)
        {
            var salutation = await _salutationRepository.GetByIdAsync(request.Id);
            if (salutation == null)
            {
                var resposeObject = new Response<GetSalutationListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var salutationDto = _mapper.Map<GetSalutationListVm>(salutation);
            var response = new Response<GetSalutationListVm>(salutationDto, "success");
            return response;
        }
    }
}
