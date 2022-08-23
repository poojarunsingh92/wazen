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

namespace WazenCustomer.Application.Features.NationalIdTypes.Queries.GetNationalIdTypeById
{
    public class GetNationalIdTypeByIdQueryListHandler : IRequestHandler<GetNationalIdTypeByIdQuery, Response<GetNationalIdListVm>>
    {
        private readonly INationalIdTypeRepository _nationalIdTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetNationalIdTypeByIdQueryListHandler(IMapper mapper, INationalIdTypeRepository nationalIdTypeRepository, ILogger<GetNationalIdTypeByIdQueryListHandler> logger)
        {
            _mapper = mapper;
            _nationalIdTypeRepository = nationalIdTypeRepository;
            _logger = logger;
        }
        public async Task<Response<GetNationalIdListVm>> Handle(GetNationalIdTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var nationalIdType = await _nationalIdTypeRepository.GetByIdAsync(request.Id);
            if (nationalIdType == null)
            {
                var resposeObject = new Response<GetNationalIdListVm>(request.Id + " is not available");
                return resposeObject;
            }

            var maritalStatusDto = _mapper.Map<GetNationalIdListVm>(nationalIdType);
            var response = new Response<GetNationalIdListVm>(maritalStatusDto, "success");
            return response;
        }
    }
}
