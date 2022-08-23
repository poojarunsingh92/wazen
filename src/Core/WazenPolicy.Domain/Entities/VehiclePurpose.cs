using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class VehiclePurpose : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        public string VehiclePurposeName { get; set; }
    }
}