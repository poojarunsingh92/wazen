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

namespace WazenCustomer.Application.Features.Genders.Queries.GetGenderById
{
    public class GetGenderByIdQueryHandler : IRequestHandler<GetGenderByIdQuery, Response<GetGenderListVm>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetGenderByIdQueryHandler(IMapper mapper, IGenderRepository genderRepository, ILogger<GetGenderByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _logger = logger;
        }
        public async Task<Response<GetGenderListVm>> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {

            var gender = await _genderRepository.GetByIdAsync(request.Id);
            if (gender == null)
            {
                var resposeObject = new Response<GetGenderListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var genderDto = _mapper.Map<GetGenderListVm>(gender);
            var response = new Response<GetGenderListVm>(genderDto, "success");
            return response;
        }
    }
}
