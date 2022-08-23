using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WazenPolicy.Application.Contracts.Persistence;
using WazenPolicy.Application.Helper;
using WazenPolicy.Application.Responses;

namespace WazenPolicy.Application.Features.CustomerPolicy.Commands.CreateCustomerPolicy
{
    public class CreateCustomerPolicyCommandHandler : IRequestHandler<CreateCustomerPolicyCommand, Response<CustomerPolicyDto>>
    {
        private readonly ICustomerPolicyRepository _customerPolicyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerPolicyCommandHandler> _logger;
        private readonly CustomerPolicyProducer _ProducerService;

        public CreateCustomerPolicyCommandHandler(IMapper mapper, ICustomerPolicyRepository customerPolicyRepository, ILogger<CreateCustomerPolicyCommandHandler> logger, CustomerPolicyProducer producerService)
        {
            _mapper = mapper;
            _customerPolicyRepository = customerPolicyRepository;
            _logger = logger;
            _ProducerService = producerService;
        }

        public async Task<Response<CustomerPolicyDto>> Handle(CreateCustomerPolicyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var createCustomerPolicyCommandResponse = new Response<CustomerPolicyDto>();

            var validator = new CreateCustomerPolicyCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCustomerPolicyCommandResponse.Succeeded = false;
                createCustomerPolicyCommandResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCustomerPolicyCommandResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var customerPolicy = new WazenPolicy.Domain.Entities.CustomerPolicy()
                {
                    CustomerVehicleID = request.CustomerVehicleID,
                    PurchaseService = request.PurchaseService,
                    Cancellation = request.Cancellation,
                    ReasonforCancellation = request.ReasonforCancellation,
                    ClaimIfAny = request.ClaimIfAny,
                    InsuranceCompanyName = request.InsuranceCompanyName,
                    InsuranceType = request.InsuranceType,
                    PolicyName = request.PolicyName,
                    PolicyType = request.PolicyType,
                    StartDate = request.StartDate,
                    ExpiryDate = request.ExpiryDate,
                    PolicyNo = request.PolicyNo,
                    Status = request.Status,
                    RegistrationType = request.RegistrationType,
                    RegistrationNumber = request.RegistrationNumber,
                    SequenceNo = request.SequenceNo,
                    EffectiveCancellationDate = DateTime.Now,
                    LocoftheDamagedVehicle = request.LocoftheDamagedVehicle,
                    ServicesAddonsTypes = request.ServicesAddonsTypes,
                    ListofAbandonedQuotes = request.ListofAbandonedQuotes,
                    RequestDateTime = request.RequestDateTime,
                    Description = request.Description,
                    PolicyPriced = request.PolicyPriced,
                    PolicyAmountPaid = request.PolicyAmountPaid,
                    CoverNote = request.CoverNote,
                    ImagesUploaded = request.ImagesUploaded,
                    PremiumAmount = request.PremiumAmount,
                    AdditionalCoverageAmount = request.AdditionalCoverageAmount,
                    ServiceChargeAmount = request.ServiceChargeAmount,
                    VAT = request.VAT,
                    GroundTotal = request.GroundTotal
                };
                string topic = "policy";
                customerPolicy = await _customerPolicyRepository.AddAsync(customerPolicy);
                _ProducerService.SendOrderRequest(topic, JsonSerializer.Serialize(customerPolicy));
                
                createCustomerPolicyCommandResponse.Data = _mapper.Map<CustomerPolicyDto>(customerPolicy);
                createCustomerPolicyCommandResponse.Succeeded = true;
                createCustomerPolicyCommandResponse.Message = "success";

                _logger.LogInformation("Handle Completed");
            }
            return createCustomerPolicyCommandResponse;
        }
    }
}
