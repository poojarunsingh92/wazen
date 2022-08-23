using System;
using System.Collections.Generic;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class FAQ : AuditableEntity
    {
        public Guid ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Module { get; set; }
        public Boolean DisplayOnHome { get; set; }
        public Boolean Status { get; set; }
    }
}
