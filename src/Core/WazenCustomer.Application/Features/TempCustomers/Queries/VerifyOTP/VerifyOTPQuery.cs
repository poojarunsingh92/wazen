using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.VerifyOTP
{
    public class VerifyOTPQuery : IRequest<Response<VerifyOTPVm>>
    {
        public string Email { get; set; }
        public string VerifyCode { get; set; }
    }
}