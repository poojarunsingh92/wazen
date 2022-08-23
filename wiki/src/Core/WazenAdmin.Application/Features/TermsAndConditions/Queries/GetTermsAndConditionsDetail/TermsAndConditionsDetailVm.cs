using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Features.TermsAndConditions.Queries.GetTermsAndConditionsDetail
{
    public class TermsAndConditionsDetailVm
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

        public string SerialNo { get; set; }
        public string Heading { get; set; }
    }
}
