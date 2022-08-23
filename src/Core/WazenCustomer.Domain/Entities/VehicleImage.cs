using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class VehicleImage : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public string VehicleImages { get; set; }

        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
    }
}