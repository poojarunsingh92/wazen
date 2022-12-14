using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WazenPolicy.Domain.Common;

namespace WazenPolicy.Domain.Entities
{
    public class ICAdditionalCoverr : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid? ICID { get; set; }  //FK
        public string ValueAr { get; set; }
        public string ValueEng { get; set; }
        public string Description { get; set; }

        //ForeignKey
        [ForeignKey("ICID")]
        public InsuranceCompany InsuranceCompany { get; set; }
    }
}