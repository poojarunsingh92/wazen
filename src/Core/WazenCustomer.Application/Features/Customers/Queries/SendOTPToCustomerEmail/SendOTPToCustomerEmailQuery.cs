using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.Customers.Queries.SendOTPToCustomerEmail
{
    public class SendOTPToCustomerEmailQuery : IRequest<Response<SendOTPToCustomerEmailVm>>
    {
        public string Email { get; set; }
    }
}
