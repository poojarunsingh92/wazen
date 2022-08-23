using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenCustomer.Application.Responses;

namespace WazenCustomer.Application.Features.AdditionalCoverage.Commands.CreateAdditionalCoverge
{
   public class CreateAdditionalCoverageCommand :  IRequest<Response<CreateAdditionalCoverageDto>>
    {
        public Guid? CustomerPolicyId { get; set; }         //FK
        public string AdditionalCoverage { get; set; }
    }
}
