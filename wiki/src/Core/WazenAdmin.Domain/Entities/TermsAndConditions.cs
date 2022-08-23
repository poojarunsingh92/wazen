using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class TermsAndConditions : AuditableEntity
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string SerialNo { get; set; }
        public string Heading { get; set; }
    }
}
