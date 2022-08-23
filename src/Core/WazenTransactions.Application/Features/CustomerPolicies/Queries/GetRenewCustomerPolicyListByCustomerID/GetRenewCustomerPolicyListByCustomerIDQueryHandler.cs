using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Contracts.Persistence;
using WazenTransactions.Application.Responses;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetRenewCustomerPolicyListByCustomerID
{
    public class GetRenewCustomerPolicyListByCustomerIDQueryHandler : IRequestHandler<GetRenewCustomerPolicyListByCustomerIDQuery, Response<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;

        public GetRenewCustomerPolicyListByCustomerIDQueryHandler(ILogger<GetRenewCustomerPolicyListByCustomerIDQueryHandler> logger, IMapper mapper, IVehicleRepository vehicleRepository,ICustomerPolicyRepository customerPolicyRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _customerPolicyRepository = customerPolicyRepository;
        }

        public async Task<Response<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>>> Handle(GetRenewCustomerPolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var allVehicleAndPolicies = new List<RenewCustomerPolicyListByCustomerIDVm>();
            var allVehiclePolicies = await _customerPolicyRepository.GetCustomerVehiclePolicyListByCustomerID(request.CustomerID);
            
            foreach(var vehiclePolicy in allVehiclePolicies)
            {
                if((vehiclePolicy.VehicleInformationData.PolicyInformationData.ExpiryDate-DateTime.Now).Days<=30)
                {
                    allVehicleAndPolicies.Add(vehiclePolicy);
                }
            }
            var VehiclePolicyList = _mapper.Map<List<RenewCustomerPolicyListByCustomerIDVm>>(allVehicleAndPolicies);
            var response = new Response<IEnumerable<RenewCustomerPolicyListByCustomerIDVm>>(VehiclePolicyList);
            return response;
        }
    }
}
