using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class VehicleViolation : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }

        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }

        //[ForeignKey("ViolationTypeId")]
        //public ViolationType ViolationType { get; set; }
    }
}