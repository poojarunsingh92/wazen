using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetPolicyDetail
{
    public class GetCustomerPolicyDetailQueryHandler : IRequestHandler<GetCustomerPolicyDetailQuery, Response<CustomerPolicyDetailVm>>
    {

        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<GetCustomerPolicyDetailQueryHandler> _logger;

        public GetCustomerPolicyDetailQueryHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, IVehicleRepository vehicleRepository, ILogger<GetCustomerPolicyDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        public async Task<Response<CustomerPolicyDetailVm>> Handle(GetCustomerPolicyDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var customerPolicyExist = await _customerPolicyRepository.GetByIdAsync(request.ID);
            if (customerPolicyExist == null)
            {
                var resposeObject = new Response<CustomerPolicyDetailVm>(request.ID + " is not available");
                return resposeObject;

            }
            CustomerPolicyDetailVm customerPolicy = new CustomerPolicyDetailVm();

            customerPolicy.PolicyNo = customerPolicyExist.PolicyNo;
            customerPolicy.InsuranceCompanyName = customerPolicyExist.InsuranceCompanyName;
            customerPolicy.PolicyType = customerPolicyExist.PolicyType;
            customerPolicy.RegistrationNumber = customerPolicyExist.RegistrationNumber;
            customerPolicy.EffectiveCancellationDate = customerPolicyExist.EffectiveCancellationDate.Value;
            customerPolicy.StartDate = customerPolicyExist.StartDate.Value;
            customerPolicy.ExpiryDate = customerPolicyExist.ExpiryDate.Value;
            customerPolicy.Status = customerPolicyExist.Status;
            customerPolicy.PremiumAmount = customerPolicyExist.PremiumAmount;
            customerPolicy.AdditionalCoverageAmount = customerPolicyExist.AdditionalCoverageAmount;
            customerPolicy.ServiceChargeAmount = customerPolicyExist.ServiceChargeAmount;
            customerPolicy.VAT = customerPolicyExist.VAT;
            customerPolicy.GroundTotal = customerPolicyExist.GroundTotal;
            customerPolicy.AdditionalCoverage = customerPolicyExist.AdditionalCoverage;
            //var vehicle = (await _vehicleRepository.GetVehicleDetailsByVehicleIDAsync(Policy.VehicleID));
            //customerPolicy.VehicleMake = vehicle.VehicleMake;
            //customerPolicy.VehicleModel = vehicle.VehicleModel;
            //customerPolicy.VehicleNumber = vehicle.VehicleNumber;
            var response = new Response<CustomerPolicyDetailVm>(customerPolicy);
            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
