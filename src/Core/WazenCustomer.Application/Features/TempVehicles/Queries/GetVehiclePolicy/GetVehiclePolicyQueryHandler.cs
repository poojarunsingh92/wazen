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

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetVehiclePolicy
{
    public class GetVehiclePolicyQueryHandler : IRequestHandler<GetVehiclePolicyQuery, Response<VehicleInfo>>
    {
        private readonly ILogger<GetVehiclePolicyQueryHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IAdditionalCoverageRepository _additionalCoverageRepository;

        public GetVehiclePolicyQueryHandler(ILogger<GetVehiclePolicyQueryHandler> logger, IMediator mediator, IMapper mapper, IVehicleRepository vehicleRepository, ITransactionRepository transactionRepository, ICustomerPolicyRepository customerPolicyRepository, IAdditionalCoverageRepository additionalCoverageRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _transactionRepository = transactionRepository;
            _customerPolicyRepository = customerPolicyRepository;
            _additionalCoverageRepository = additionalCoverageRepository;
        }

        public async Task<Response<VehicleInfo>> Handle(GetVehiclePolicyQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<VehicleInfo>();
            var vehicle = await _vehicleRepository.GetVehicleBySequenceNumberAndCustomerID(request.SequenceNumber, request.CustomerID);
            if(vehicle==null)
            {
                var resposeObject = new Response<VehicleInfo>(request.CustomerID+" or "+request.SequenceNumber+" is not found");
                return resposeObject;
            }
            var transaction = await _transactionRepository.GetTransactionByCustomerID(request.CustomerID);
            if(transaction==null)
            {
                var resposeObject = new Response<VehicleInfo>(request.CustomerID +" is not found");
                return resposeObject;
            }
            var customerPolicy = await _customerPolicyRepository.GetCustomerPolicyByVehicleIDTransactionID(vehicle.ID, transaction.Id);
            if (customerPolicy==null)
            {
                var resposeObject = new Response<VehicleInfo>(vehicle.ID + " is not found");
                return resposeObject;
            }
            var additionalCoverage = await _additionalCoverageRepository.GetAdditionalCoverageByPolicyID(customerPolicy.Id);
            response.Data = _mapper.Map<VehicleInfo>(vehicle);
            response.Data.CustomerPolicyInfo = _mapper.Map<CustomerPolicyInformation>(customerPolicy);
            response.Data.CustomerPolicyInfo.CustomerPolicyAdditionalCoverage = _mapper.Map<List<AdditionalCoverageInfo>>(additionalCoverage);
            return response;
        }
    }
}
