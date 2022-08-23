using System;
using System.Collections.Generic;
using System.Text;

namespace WazenPolicy.Application.Features.InsuranceCompanies.Queries.GetInsuranceCompaniesList
{
    public class InsuranceCompanyListVm
    {
        public Guid Id { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string BeneficiaryName { get; set; }
        public string IBanNum { get; set; }
        public string BankIdCode { get; set; }
    }
}
