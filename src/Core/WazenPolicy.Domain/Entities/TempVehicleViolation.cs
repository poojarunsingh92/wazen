using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class TempVehicleViolation : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid? VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int? ViolationTypeId { get; set; }

        [ForeignKey("VehicleID")]
        public TempVehicle TempVehicle { get; set; }

        [ForeignKey("ViolationTypeId")]
        public ViolationType ViolationType { get; set; }
    }
}