using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
   public class CustomerPolicy : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid? CustomerVehicleID { get; set; }    //FK
        public string PurchaseService { get; set; }
        public string Cancellation { get; set; }
        public string ReasonforCancellation { get; set; }
        public string ClaimIfAny { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceType { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string PolicyNo{ get; set; }
        public string Status { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationNumber { get; set; }
        public string SequenceNo { get; set; }
        public DateTime? EffectiveCancellationDate { get; set; }
        public string LocoftheDamagedVehicle { get; set; }
        public string ServicesAddonsTypes { get; set; }
        public string ListofAbandonedQuotes { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string Description { get; set; }
        public string PolicyPriced { get; set; }
        public string PolicyAmountPaid { get; set; }
        public string CoverNote { get; set; }
        public string ImagesUploaded { get; set; }
        public string PremiumAmount { get; set; }
        public string AdditionalCoverageAmount { get; set; }
        public string AdditionalCoverage { get; set; }
        public string ServiceChargeAmount { get; set; }
        public string VAT { get; set; }
        public string GroundTotal { get; set; }
        public Boolean IsUpgraded { get; set; }
        public Boolean IsCancelled { get; set; }

        //ForeignKey
        [ForeignKey("CustomerVehicleID")]
        public CustomerVehicle CustomerVehicle { get; set; }
    }
}