using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.GetQuoteVerifyOTP
{
    public class GetQuoteVerifyOTPQuery : IRequest<Response<GetQuoteVerifyOTPVm>>
    {
        public Guid CustomerId { get; set; }
        public string VerifyCode { get; set; }
    }
}
