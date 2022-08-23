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

namespace WazenCustomer.Application.Features.TempCustomers.Queries.VerifyOTP
{
    public class VerifyOTPQueryHandler : IRequestHandler<VerifyOTPQuery, Response<VerifyOTPVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;

        public VerifyOTPQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, ILogger<VerifyOTPQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _tempCustomerRepository = tempCustomerRepository;
        }

        public async Task<Response<VerifyOTPVm>> Handle(VerifyOTPQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<VerifyOTPVm>();
            var customer = await _customerRepository.GetCustomerByEmailVerifyCode(request.Email, request.VerifyCode);

            if (customer == null)
            {
                var tempCustomer = await _tempCustomerRepository.GetTempCustomerByEmailVerifyCode(request.Email, request.VerifyCode);

                if (tempCustomer == null)
                {
                    var resposeObject = new Response<VerifyOTPVm>(request.Email + " or " + request.VerifyCode + " is incorrect");
                    return resposeObject;
                }
                var tempCustomerDetailDto = _mapper.Map<VerifyOTPVm>(tempCustomer);
                response = new Response<VerifyOTPVm>(tempCustomerDetailDto, "success");
                return response;
            }
            //Here need to write the update code to make the customer Verified through OTP
            customer.IsVerified = true;
            await _customerRepository.UpdateAsync(customer);
            var customerDetailDto = _mapper.Map<VerifyOTPVm>(customer);
            response = new Response<VerifyOTPVm>(customerDetailDto, "success");
            return response;
        }
    }
}