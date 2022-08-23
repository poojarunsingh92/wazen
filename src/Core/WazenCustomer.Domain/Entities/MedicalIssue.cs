using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class MedicalIssue : AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        public string MedicalIssueName { get; set; }
    }
}