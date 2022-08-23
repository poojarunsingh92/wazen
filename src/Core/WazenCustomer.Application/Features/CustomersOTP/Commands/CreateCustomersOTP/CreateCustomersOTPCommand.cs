using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.CustomersOTP.Commands.CreateCustomersOTP
{
    public class CreateCustomersOTPCommand : IRequest<Response<CustomersOTPDto>>
    {
        public int VerifyCode { get; set; }
        public string NIN { get; set; }
    }
}
