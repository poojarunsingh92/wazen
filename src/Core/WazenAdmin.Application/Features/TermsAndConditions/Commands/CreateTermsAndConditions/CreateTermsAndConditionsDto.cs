using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.TermsAndConditions.Commands.CreateTermsAndConditions
{
    public class CreateTermsAndConditionsDto
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public string SerialNo { get; set; }
        public string Heading { get; set; }

    }
}
