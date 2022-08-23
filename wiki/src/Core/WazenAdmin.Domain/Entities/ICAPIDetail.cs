using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WazenAdmin.Domain.Common;

namespace WazenAdmin.Domain.Entities
{
    public class ICAPIDetail : AuditableEntity
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ICID { get; set; }
        public string EndPointURL { get; set; }
        public string RequestType { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string APIType { get; set; }

        //ForeignKey
        [ForeignKey("ICID")]
        public InsuranceCompany InsuranceCompany { get; set; }
    }
}
