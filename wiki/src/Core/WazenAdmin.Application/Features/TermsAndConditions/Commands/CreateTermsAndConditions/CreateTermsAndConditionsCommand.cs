using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions
{
    public class CreateTermsAndConditionsCommand : IRequest<Response<CreateTermsAndConditionsDto>>
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string SerialNo { get; set; }
        public string Heading { get; set; }
    }
}
