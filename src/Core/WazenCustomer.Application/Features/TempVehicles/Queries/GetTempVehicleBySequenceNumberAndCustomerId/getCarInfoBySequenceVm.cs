using System;
using System.Collections.Generic;
using System.Text;

namespace WazenCustomer.Application.Features.TempVehicles.Queries.GetTempVehicleBySequenceNumberAndCustomerId
{
    public class getCarInfoBySequenceVm
    {
        public int logId { get; set; }
        public string plateNumber { get; set; }
        public string plateText1 { get; set; }
        public string plateText2 { get; set; }
        public string plateText3 { get; set; }
        public string plateTypeCode { get; set; }
        public string vehicleMaker { get; set; }
        public string vehicleModel { get; set; }
        public string majorColor { get; set; }
        public string chassisNumber { get; set; }
        public string modelYear { get; set; }
        public string vehicleLoad { get; set; }
        public string vehicleWeight { get; set; }
        public string cylinders { get; set; }
        public string bodyType { get; set; }
        public string regExpiryDate { get; set; }
        public string regplace { get; set; }
    }
}
