using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Queries.GetAdditionalCoverageByPolicyID
{
    public class GetAdditionalCoverageByPolicyIDQueryHandler : IRequestHandler<GetAdditionalCoverageByPolicyIDQuery, Response<AdditionalCoverageByPolicyIDVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;

        public GetAdditionalCoverageByPolicyIDQueryHandler(IMapper mapper, ILogger<GetAdditionalCoverageByPolicyIDQueryHandler> logger, IAdditionalCoverageRepository additionalCoverageRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _additionalCoverageRepository = additionalCoverageRepository;
        }
        public async Task<Response<AdditionalCoverageByPolicyIDVm>> Handle(GetAdditionalCoverageByPolicyIDQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<AdditionalCoverageByPolicyIDVm>();
            var additionalCoverage = await _additionalCoverageRepository.GetAdditionalCoverageByPolicyID(request.CustomerPolicyId);
            if (additionalCoverage == null)
            {
                var resposeObject = new Response<AdditionalCoverageByPolicyIDVm>(request.CustomerPolicyId + " is not available");
                return resposeObject;
            }

            var json = JObject.Parse("{\"additionalcoverage\":" + additionalCoverage.AdditionalCoverage+"}");
            List<AdditionalCoverage> deserializdedata = new List<AdditionalCoverage>();
            foreach (var data in json)
            {
                JToken value = data.Value;
                deserializdedata = JsonConvert.DeserializeObject<List<AdditionalCoverage>>(value.ToString());
            }

            response.Data = new AdditionalCoverageByPolicyIDVm()
            {
                Id=additionalCoverage.Id,
                CustomerPolicyId= additionalCoverage.CustomerPolicyId,
                AdditionalCoverage=deserializdedata
            };
            response.Succeeded = true;
            response.Message = "success";
            return response;
        }
    }
}
