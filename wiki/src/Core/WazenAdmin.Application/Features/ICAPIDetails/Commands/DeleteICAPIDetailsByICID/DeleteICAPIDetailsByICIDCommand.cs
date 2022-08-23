using WazenAdmin.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.ICAPIDetails.Commands.DeleteICAPIDetailsByICID
{
    public class DeleteICAPIDetailsByICIDCommand : IRequest
    {
        public Guid ICID { get; set; }
    }
}
