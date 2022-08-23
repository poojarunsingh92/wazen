using AutoMapper;
using WazenAdmin.Application.Contracts.Persistence;
using WazenAdmin.Application.Responses;
using WazenAdmin.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WazenAdmin.Application.Exceptions;
using System;

namespace WazenAdmin.Application.Features.ICAPIDetails.Queries.GetICAPIDetailsListByICID
{
    public class GetICAPIDetailsListByICIDQueryHandler : IRequestHandler<GetICAPIDetailsListByICIDQuery, Response<List<ICAPIDetailsListByICIDVm>>>    
    {
        private readonly IICAPIDetailRepository _iCAPIDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetICAPIDetailsListByICIDQueryHandler(IMapper mapper, IICAPIDetailRepository iCAPIDetailsRepository, ILogger<GetICAPIDetailsListByICIDQueryHandler> logger)
        {
            _mapper = mapper;
            _iCAPIDetailsRepository = iCAPIDetailsRepository;
            _logger = logger;
        }

        public async Task<Response<List<ICAPIDetailsListByICIDVm>>> Handle(GetICAPIDetailsListByICIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<ICAPIDetailsListByICIDVm>>();
            _logger.LogInformation("Handle Initiated");
            var allICAPIDetails = (await _iCAPIDetailsRepository.ListAllByICIDAsync(request.ICID));
            if (allICAPIDetails == null)
            {
                var resposeObject = new Response<List<ICAPIDetailsListByICIDVm>>(request.ICID + " is not available");
                return resposeObject;
            }
            var icAPIDetails = new List<ICAPIDetailsListByICIDVm>();
            
            foreach (var item in allICAPIDetails)
            {
                ICAPIDetailsListByICIDVm icAPI = new ICAPIDetailsListByICIDVm();
                icAPI.ID = item.ID;
                icAPI.ICID = item.ICID;
                icAPI.EndPointURL = item.EndPointURL;
                icAPI.RequestType = item.RequestType;
                icAPI.Header = item.Header;
                icAPI.Body = item.Body;
                icAPI.APIType = item.APIType;

                icAPIDetails.Add(icAPI);
            }            
            if(icAPIDetails.Count()==0)
            {
                return response;
            }
            response = new Response<List<ICAPIDetailsListByICIDVm>>(icAPIDetails);
            return response;
        }
    }
}
