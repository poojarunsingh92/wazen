using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class TempVehicleImage : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public string VehicleImages { get; set; }

        [ForeignKey("VehicleID")]
        public TempVehicle TempVehicle { get; set; }
    }
}