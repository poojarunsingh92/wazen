using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.TempCustomers.Queries.SendOTP
{
    public class SendOTPQuery : IRequest<Response<SendOTPVm>>
    {
        public Guid CustomerID { get; set; }
    }
}