using System;
using System.Collections.Generic;
using System.Text;

namespace Wazen.Application.Features.Payment.Command.CreatePaymentCommand
{
    public class VehicleDto
    {
        public Guid ID { get; set; }
        public Guid ICID { get; set; }
        //public Guid? CustomerID { get; set; }
        public string AdditionalCoverageAmount { get; set; }
        public string AdditionalCoverage { get; set; }
        public string ServiceChargeAmount { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PolicyTypeId { get; set; }
        public string PremiumAmount { get; set; }
        public string VAT { get; set; }
    }
}
