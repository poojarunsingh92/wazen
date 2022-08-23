using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.Users.Queries.VerifyOTP
{
   public class VerifyOTPQuery : IRequest<Response<VerifyOTPVm>>
    {
        public string Email { get; set; }
        public string VerifyCode { get; set; }
        // public string ContactNo { get; set; }

    }
}
