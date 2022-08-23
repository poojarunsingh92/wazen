using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Queries.GetCustomerCancelPolicyQuote
{
    public class GetCustomerCancelPolicyQuoteQueryHandler : IRequestHandler<GetCustomerCancelPolicyQuoteQuery, Response<CustomerCancelPolicyQuoteVm>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        //private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<GetCustomerCancelPolicyQuoteQueryHandler> _logger;

        public GetCustomerCancelPolicyQuoteQueryHandler(ICustomerPolicyRepository customerPolicyRepository/*, IVehicleRepository vehicleRepository*/, ILogger<GetCustomerCancelPolicyQuoteQueryHandler> logger)
        {
            _customerPolicyRepository = customerPolicyRepository;
            //_vehicleRepository = vehicleRepository;
            _logger = logger;
        }
        public async Task<Response<CustomerCancelPolicyQuoteVm>> Handle(GetCustomerCancelPolicyQuoteQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            //var vehicle = await _vehicleRepository.GetVehicleBySeqNumCustomIdAsync(request.SequenceNumber, request.CustomID);
            //if (vehicle == null)
            //{
            //    var resposeObject = new Response<CustomerCancelPolicyQuoteVm>("Sequence Number or Custom Id is not found");
            //    return resposeObject;
            //}

            var customerPolicy = await _customerPolicyRepository.GetByCustomerVehicleIDPolicyNameAsync(Guid.NewGuid()/*vehicle.VehicleID*/, request.PolicyName);

            if (customerPolicy == null)
            {
                var resposeObject = new Response<CustomerCancelPolicyQuoteVm>(Guid.NewGuid()/*vehicle.VehicleID*/ + " OR" + request.PolicyName + " is not found");
                return resposeObject;
            }
            CustomerCancelPolicyQuoteVm customerDetailDto = new CustomerCancelPolicyQuoteVm();
            customerDetailDto.Id = customerPolicy.ID;
            customerDetailDto.CustomerVehicleID = (Guid)customerPolicy.CustomerVehicleID;
            customerDetailDto.VehicleMake = ""; //vehicle.VehicleMake;
            customerDetailDto.VehicleModel = ""; //vehicle.VehicleModel;
            customerDetailDto.VehicleNumber = ""; //vehicle.VehicleNumber;
            customerDetailDto.RegistrationNumber = ""; //vehicle.VehicleRegistrationNumber;
            customerDetailDto.PolicyType = customerPolicy.PolicyType;
            customerDetailDto.PolicyName = customerPolicy.PolicyName;
            customerDetailDto.ExpiryDate = customerPolicy.ExpiryDate;

            var response = new Response<CustomerCancelPolicyQuoteVm>(customerDetailDto);
            _logger.LogInformation("Handle Completed");
            return response;
        }
    }
}
