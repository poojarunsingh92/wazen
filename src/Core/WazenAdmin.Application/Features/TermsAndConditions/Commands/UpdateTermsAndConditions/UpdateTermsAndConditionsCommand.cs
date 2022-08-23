using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Application.Responses;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.UpdateTermsAndConditions
{
    public class UpdateTermsAndConditionsCommand : IRequest<Response<Guid>>
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public string SerialNo { get; set; }
        public string Heading { get; set; }
    }
}
