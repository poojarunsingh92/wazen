using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail
{
    public class SendOTPToCustomerEmailVm : IRequest<Response<SendOTPToCustomerEmailVm>>
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string VerifyCode { get; set; }
    }
}
