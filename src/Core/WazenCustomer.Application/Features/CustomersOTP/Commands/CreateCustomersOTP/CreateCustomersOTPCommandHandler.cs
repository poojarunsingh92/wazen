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
using WazenCustomer.Domain.Entities;

namespace WazenCustomer.Application.Features.CustomersOTP.Commands.CreateCustomersOTP
{
    public class CreateCustomersOTPCommandHandler : IRequestHandler<CreateCustomersOTPCommand, Response<CustomersOTPDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomersOTPCommandHandler> _logger;
        private readonly ICustomerOTPRepository _customerOTPRepository;

        public CreateCustomersOTPCommandHandler(IMapper mapper, ILogger<CreateCustomersOTPCommandHandler> logger, ICustomerOTPRepository customerOTPREpository)
        {
            _mapper = mapper;
            _logger = logger;
            _customerOTPRepository = customerOTPREpository;
        }
        public async Task<Response<CustomersOTPDto>> Handle(CreateCustomersOTPCommand request, CancellationToken cancellationToken)
        {

            var customerOTPResponse = new Response<CustomersOTPDto>();
            var validator = new CreateCustomersOTPCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                customerOTPResponse.Succeeded = false;
                customerOTPResponse.Errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    customerOTPResponse.Errors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var customerOTP = new CustomerOTP()
                {
                    NIN = request.NIN,
                    VerifyCode=request.VerifyCode
                };
                customerOTP = await _customerOTPRepository.AddAsync(customerOTP);
                customerOTPResponse.Data = _mapper.Map<CustomersOTPDto>(customerOTP);
                customerOTPResponse.Succeeded = true;
                customerOTPResponse.Message = "success";
            }

            return customerOTPResponse;
        }
    }
}
