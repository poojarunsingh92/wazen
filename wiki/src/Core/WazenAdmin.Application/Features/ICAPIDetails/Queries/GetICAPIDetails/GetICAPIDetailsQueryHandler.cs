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

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries
{
    public class GetICAPIDetailsQueryHandler : IRequestHandler<GetICAPIDetailsQuery, Response<ICAPIDetailsVm>>
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetICAPIDetailsQueryHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<ICAPIDetailsVm>> Handle(GetICAPIDetailsQuery request, CancellationToken cancellationToken)
        {
            var iCAPIDetails = await _iCAPIDetailsRepository.GetByIdAsync(request.ID);
            if (iCAPIDetails == null)
            {
                var resposeObject = new Response<ICAPIDetailsVm>(request.ID + " is not available");
                return resposeObject;
            }
            var iCAPIDetailDto = _mapper.Map<ICAPIDetailsVm>(iCAPIDetails);
            var response = new Response<ICAPIDetailsVm>(iCAPIDetailDto,"success");
            return response;
        }
    }
}
