using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class AboutUs : AuditableEntity
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
