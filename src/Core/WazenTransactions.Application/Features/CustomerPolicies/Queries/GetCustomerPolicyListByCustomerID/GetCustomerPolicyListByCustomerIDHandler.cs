using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenTransactions.Application.Responses;
using WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID;

using WazenTransactions.Application.Contracts.Persistence;

namespace WazenTransactions.Application.Features.CustomerPolicies.Queries.GetCustomerPolicyListByCustomerID
{
    public class GetCustomerPolicyListByCustomerIDHandler : IRequestHandler<GetCustomerPolicyListByCustomerIDQuery, Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>>
    {
        private readonly ICustomerVehicleRepository _customerVehicleRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;

        public GetCustomerPolicyListByCustomerIDHandler(IMapper mapper, ICustomerVehicleRepository customerVehicleRepository, ICustomerPolicyRepository customerPolicyRepository, ILogger<GetCustomerPolicyListByCustomerIDHandler> logger,
            IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _customerVehicleRepository = customerVehicleRepository;
            _customerPolicyRepository = customerPolicyRepository;
        }
        public async Task<Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>> Handle(GetCustomerPolicyListByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            var customerVehicles = await _vehicleRepository.GetVehicleListByCustomerID(request.CustomerID);
            if (customerVehicles == null)
            {
                var resposeObject = new Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>(request.CustomerID + " is not available");
                return resposeObject;
            }
            var customerPolicies = new List<GetCustomerPolicyListByCustomerIDVm>();
            foreach (var vehicle in customerVehicles)
            {
                var customerPolicy = await _customerPolicyRepository.GetCustomerPolicyByCustomerVehicleID(vehicle.ID);
                var policy = _mapper.Map<GetCustomerPolicyListByCustomerIDVm>(customerPolicy);
                if (customerPolicy == null)
                {
                    continue;
                }
                customerPolicies.Add(new GetCustomerPolicyListByCustomerIDVm()
                {

                    CustomerPolicyAdditionalCoverage = _mapper.Map<List<CustomerPolicyAdditionalCoverageVM>>(customerPolicy.CustomerPolicyAdditionalCoverage),
                    CustomerVehicleId = customerPolicy.VehicleId,
                    ExpiryDate = customerPolicy.ExpiryDate,
                   // ICID = customerPolicy.Ic,
                    ID = customerPolicy.Id,
                    IssuedDate = customerPolicy.IssueDate,
                    PolicyNumber = customerPolicy.PolicyNumber,
                    PolicyTypeId = customerPolicy.PolicyTypeId,
                    PremiumDetails = customerPolicy.PremiumAmount,
                    StartDate = customerPolicy.StartDate,
                    //Status = customerPolicy.st
                
                    TransactionId = customerPolicy.TransactionId
                });
            }

            var response = new Response<IEnumerable<GetCustomerPolicyListByCustomerIDVm>>();
            response.Data = customerPolicies;
            response.Succeeded = true;
            return response;
        }
    }
}

