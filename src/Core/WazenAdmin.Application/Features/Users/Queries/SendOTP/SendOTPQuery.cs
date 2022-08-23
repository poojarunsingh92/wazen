using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Queries.SendOTP
{
   public class SendOTPQuery : IRequest<Response<SendOTPVm>>
    {
        public string Email { get; set; }
       // public string ContactNo { get; set; }
    }
}
