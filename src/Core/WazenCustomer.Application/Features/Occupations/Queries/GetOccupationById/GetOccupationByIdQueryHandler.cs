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

namespace WazenCustomer.Application.Features.Occupations.Queries.GetOccupationById
{
    public class GetOccupationByIdQueryHandler : IRequestHandler<GetOccupationByIdQuery, Response<GetOccupationListVm>>
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetOccupationByIdQueryHandler(IMapper mapper, IOccupationRepository occupationRepository, ILogger<GetOccupationByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _occupationRepository = occupationRepository;
            _logger = logger;
        }
        public async Task<Response<GetOccupationListVm>> Handle(GetOccupationByIdQuery request, CancellationToken cancellationToken)
        {
            var occupation = await _occupationRepository.GetByIdAsync(request.Id);
            if (occupation == null)
            {
                var resposeObject = new Response<GetOccupationListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var occupationDto = _mapper.Map<GetOccupationListVm>(occupation);
            var response = new Response<GetOccupationListVm>(occupationDto, "success");
            return response;
        }
    }
}
