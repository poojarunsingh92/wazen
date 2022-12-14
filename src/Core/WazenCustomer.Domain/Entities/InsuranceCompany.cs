using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WazenCustomer.Domain.Common;

namespace WazenCustomer.Domain.Entities
{
    public class InsuranceCompany : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string BeneficiaryName { get; set; }
        public string IBanNum { get; set; }
        public string BankIdCode { get; set; }
    }
}
