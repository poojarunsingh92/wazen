using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WazenCustomer.Application.Contracts.Persistence;
using WazenCustomer.Application.Exceptions;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteVerifyOTP
{
    public class GetQuoteVerifyOTPQueryHandler : IRequestHandler<GetQuoteVerifyOTPQuery, Response<GetQuoteVerifyOTPVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempCustomerRepository _tempCustomerRepository;
        private readonly IMapper _mapper;

        public GetQuoteVerifyOTPQueryHandler(IMapper mapper, ICustomerRepository customerRepository, ITempCustomerRepository tempCustomerRepository, ILogger<GetQuoteVerifyOTPQueryHandler> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _tempCustomerRepository= tempCustomerRepository;
        }

        public async Task<Response<GetQuoteVerifyOTPVm>> Handle(GetQuoteVerifyOTPQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GetQuoteVerifyOTPVm>();
            var customer = await _customerRepository.GetQuoteByVerifyCode(request.CustomerId, request.VerifyCode);

            if (customer == null)
            {
                var tempCustomer = await _tempCustomerRepository.GetQuoteByVerifyCode(request.CustomerId, request.VerifyCode);

                if (tempCustomer == null)
                {
                    var resposeObject = new Response<GetQuoteVerifyOTPVm>(request.CustomerId + " or " + request.VerifyCode + " is incorrect");
                    return resposeObject;
                }
                var tempCustomerDetailDto = _mapper.Map<GetQuoteVerifyOTPVm>(tempCustomer);
                response = new Response<GetQuoteVerifyOTPVm>(tempCustomerDetailDto, "success");
                return response;
            }
            var customerDetailDto = _mapper.Map<GetQuoteVerifyOTPVm>(customer);
            response = new Response<GetQuoteVerifyOTPVm>(customerDetailDto, "success");
            return response;
        }
    }
}