using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.SendMailToCustomer.Queries.SendMail
{
    public class SendOTPToCustomerQuery : IRequest<Response<SendOTPToCustomerVm>>
    {
        public string To { get; set; }
        public string OTP { get; set; }
        public string Subject { get; set; }
    }
}