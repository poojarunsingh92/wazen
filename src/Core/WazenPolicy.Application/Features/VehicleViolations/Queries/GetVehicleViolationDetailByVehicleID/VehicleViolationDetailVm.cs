using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.VehicleViolations.Queries.GetVehicleViolationDetailByVehicleID
{
    public class VehicleViolationDetailVm
    {
        public Guid ID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime ViolationDate { get; set; }
        public int ViolationTypeId { get; set; }
    }
}
