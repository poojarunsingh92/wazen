using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Exceptions;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsByICID
{
    public class GetICAPIDetailsByICIDHandler : IRequestHandler<GetICAPIDetailsByICIDQuery, Response<ICAPIDetailsByICIDVm>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetICAPIDetailsByICIDHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<ICAPIDetailsByICIDVm>> Handle(GetICAPIDetailsByICIDQuery request, CancellationToken cancellationToken)
        {
            var iCAPIDetailsByICID = await _iCAPIDetailsRepository.GetICAPIDetailsByICIDAsync(request.ICID);
            if (iCAPIDetailsByICID == null)
            {
                var resposeObject = new Response<ICAPIDetailsByICIDVm>(request.ICID + " is not available");
                return resposeObject;
            }
            var iCAPIDetailDto = _mapper.Map<ICAPIDetailsByICIDVm>(iCAPIDetailsByICID);
            var response = new Response<ICAPIDetailsByICIDVm>(iCAPIDetailDto);
            return response;
        }
    }
}
